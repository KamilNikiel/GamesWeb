using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamesWeb.Persistence.EntityConfigurations
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(c => c.Genre)
                .IsRequired()
                .HasMaxLength(255);
            Property(c => c.ReleaseDate)
                .IsRequired();
            Property(c => c.DateAdded)
                .IsRequired();
        }
    }
}