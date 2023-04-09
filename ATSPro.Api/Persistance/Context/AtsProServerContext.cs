using ATSPro.Api.Core.Domain;
using ATSPro.Api.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ATSPro.Api.Persistance.Context
{
    public class AtsProServerContext : DbContext
    {
        public AtsProServerContext(DbContextOptions<AtsProServerContext>options) 
            : base(options)
        {
            

        }

        public DbSet<Vehicle> Vehicles =>this.Set<Vehicle>();
        
        public DbSet<Category> Categories =>this.Set<Category>();
        
        public DbSet<AppUser> AppUsers =>this.Set<AppUser>();
        
        public DbSet<AppRole> AppRoles =>this.Set<AppRole>();
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
