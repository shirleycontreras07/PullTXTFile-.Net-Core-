using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PullOpenSource.Models
{
    public class DatosEmpleado
    {
        [Key]
        public int DatosEmpleadoId { get; set; }

        public string EmpleadoId { get; set; }

        public string Sueldo { get; set; }

        public string NoCuenta { get; set; }

    }
}
