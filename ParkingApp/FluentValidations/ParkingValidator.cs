using FluentValidation;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.FluentValidations
{
    public class ParkingValidator : AbstractValidator<Parqueo>
    {
        public ParkingValidator()
        {
            RuleFor(park => park.HoraEntrada)
                                .NotEmpty()
                                .WithMessage("Error! Debe ingresar una hora valida de ingreso.");

            RuleFor(park => park.HoraSalida)
                                .NotEmpty()
                                .WithMessage("Error! registre su hora de salida");
        }
    }
}
