using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Cliente
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Identificacion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fnacimiento { get; set; }
    }
}
