using Domain.Entidades;
using Infraestructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public class EntidadContext: DbContextBase
    {
        public EntidadContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Credito> Credito { get; set; }
        public DbSet<Cuota> Cuota { get; set; }
    }
}
