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
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);                
            Property(g => g.ReleaseDate)
                .IsRequired();
            Property(g => g.DateAdded)
                .IsRequired();
            Property(g => g.LastModified)
                .IsOptional();
            Property(g => g.GenreId)
                .IsOptional();
        }
    }
}