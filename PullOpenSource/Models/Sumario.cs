using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PullOpenSource.Models
{
    public class Sumario
    {
        [Key]
        public int SumarioId { get; set; }

        public string CanEmpleados { get; set; }

    }
}
