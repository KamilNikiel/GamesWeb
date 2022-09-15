using GamesWeb.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamesWeb.Models
{
    public class GamesWebContext : DbContext
    {
        public DbSet<IdentityModels> Customers { get; set; }
        public DbSet<Game> Games { get; set; }
        public GamesWebContext()
            : base("name=DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }

    }
}