using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamenAPI.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Categoria { get; set; }
        public decimal MontoBeca { get; set; }
        public bool IsComplete { get; internal set; }
    }
}
