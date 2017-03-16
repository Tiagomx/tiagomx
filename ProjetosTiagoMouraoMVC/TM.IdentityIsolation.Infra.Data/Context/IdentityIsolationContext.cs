using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TM.IdentityIsolation.Domain.Entities;
using TM.IdentityIsolation.Infra.Data.EntityConfig;

namespace TM.IdentityIsolation.Infra.Data.Context
{
    public class IdentityIsolationContext : DbContext
    {
        public IdentityIsolationContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
