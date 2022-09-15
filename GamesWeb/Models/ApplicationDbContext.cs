using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GamesWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityModels>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new CustomerConfiguration());
            //modelBuilder.Configurations.Add(new GameConfiguration());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}