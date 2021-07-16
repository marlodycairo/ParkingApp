using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Context;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ParkingContext context;

        public PagosController(ParkingContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult RealizarPagos(int user, int id)
        {
            Parqueo list = (from p in context.Parqueo
                            where p.Cliente.Identificacion == user && p.Id == id
                            select p).Include(p => p.Cliente).FirstOrDefault();

            double timeMinutes = (list.HoraSalida - list.HoraEntrada).TotalMinutes;

            var timeHours = ((list.HoraSalida - list.HoraEntrada).TotalHours).ToString("F", CultureInfo.InvariantCulture);

            double vrMinuto = 100;

            double total = timeMinutes * vrMinuto;

            return Ok($"TIEMPO TOTAL:  { timeMinutes } minutos, equivalente a { timeHours } horas - TOTAL A PAGAR $ { total }");
        }
    }
}
