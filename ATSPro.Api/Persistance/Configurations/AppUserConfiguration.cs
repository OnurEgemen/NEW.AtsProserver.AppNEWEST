using ATSPro.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATSPro.Api.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUsers)
                .HasForeignKey(x=>x.AppRoleId);
            
            
        }
    }

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(x=>x.Category).WithMany(x=>x.Vehicles)
                .HasForeignKey(x=>x.CategoryId);
        }
    }
}
