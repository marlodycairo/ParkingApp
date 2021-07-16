using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Context;
using ParkingApp.FluentValidations;
using ParkingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingContext context;

        public ParkingController(ParkingContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult CreateParking(Parqueo model)
        {
            var validator = new ParkingValidator();

            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest($"Error en { error.PropertyName } - { error.ErrorMessage }");
                }
            }

            context.Parqueo.Add(model);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet("{user}")]
        public ActionResult<Parqueo> GetParkingByUser(int user)
        {
            List<Parqueo> park = (from p in context.Parqueo
                            where p.Cliente.Identificacion == user
                            select p).Include(p => p.Cliente).ToList();

            return Ok(park);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Parqueo>> GetParqueos()
        {
            List<Parqueo> parking = (from p in context.Parqueo
                                     select p).Include(p => p.Cliente).ToList();

            //var data = context.Parqueo.Include(p => p.Cliente).ToList();
            //return data;
            return parking;
        }
    }
}
