using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamesWeb.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(255);
            Property(c => c.Birthdate)
                .IsOptional();
        }
    }
}