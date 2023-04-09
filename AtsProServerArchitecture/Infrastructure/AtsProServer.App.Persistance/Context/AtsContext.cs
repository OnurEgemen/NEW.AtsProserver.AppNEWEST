using AtsProServer.App.Domain.Entities;
using AtsProServer.App.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AtsProServer.App.Persistance.Context
{
    public class AtsContext : DbContext
    {
        public AtsContext(DbContextOptions<AtsContext> options) : base(options)
        {

        }

        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<AppRole>? AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
