using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Context;
using ParkingApp.FluentValidations;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ParkingContext context;
        public ClientesController(ParkingContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClient()
        {
            return context.Clientes.ToList();
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            var validator = new ClientValidator();
            ValidationResult result = validator.Validate(cliente);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest($"Hubo un error en { error.PropertyName } : { error.ErrorMessage }");
                }
            }

            context.Clientes.Add(cliente);
            context.SaveChanges();

            return cliente;
        }
    }
}
