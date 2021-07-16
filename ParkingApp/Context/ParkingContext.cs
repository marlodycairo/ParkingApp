using Microsoft.EntityFrameworkCore;
using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Context
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
        }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Parqueo> Parqueo { get; set; }
        public DbSet<Parqueoxcliente> Parqueoxcliente { get; set; }
    }
}
