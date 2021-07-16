using FluentValidation;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.FluentValidations
{
    public class ClientValidator : AbstractValidator<Cliente>
    {
        private readonly Cliente cliente = new Cliente();
        public ClientValidator()
        {
            RuleFor(client => client.Nombre).NotEmpty()
                                    .WithMessage("Debe ingresar un nombre valido.")
                                    .NotNull()
                                    .WithMessage("Debe ingresar un nombre completo.");
            RuleFor(client => client.Identificacion)
                                    .NotNull()
                                    .WithMessage("ingrese una identificacion valida.")
                                    .NotEmpty()
                                    .WithMessage("Debe ingresar su identificación.")
                                    .Must(ExistsClient)
                                    .WithMessage("Error! Cliente ya existe. Verifique sus datos.");
            RuleFor(client => client.Fnacimiento)
                                    .NotNull()
                                    .WithMessage("ingrese su fecha de nacimiento.")
                                    .NotEmpty()
                                    .WithMessage("Debe ingresar su fecha de nacimiento.");
        }

        public bool ExistsClient(int identificacion)
            //=> cliente.Equals(cliente.Identificacion == identificacion);
            => cliente.Equals(cliente.Identificacion == identificacion) ? false : true;
    }
}
