using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Parcial3.Models
{
    public class BasedeDatos : DbContext
    {
        public BasedeDatos() : base("name=LegalConnection")
        {
        }

        public DbSet<Usuarios> LM_Usuarios { get; set; }
        public DbSet<Clientes> LM_Clientes { get; set; }
        public DbSet<Casos> LM_Casos { get; set; }
        public DbSet<Documentos> LM_Documentos { get; set; }
        public DbSet<Calendario> LM_Calendario { get; set; }
        public DbSet<Seguimiento> LM_Seguimiento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}