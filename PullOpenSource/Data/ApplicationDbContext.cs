using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PullOpenSource.Models;

namespace PullOpenSource.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DatosEmpresa> DatosEmpresa { get; set; }
        public DbSet<DatosEmpleado> DatosEmpleado { get; set; }
        public DbSet<Sumario> Sumario { get; set; }


    }
}
