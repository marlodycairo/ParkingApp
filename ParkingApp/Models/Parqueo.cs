using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Parqueo
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime HoraEntrada { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime HoraSalida { get; set; }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
