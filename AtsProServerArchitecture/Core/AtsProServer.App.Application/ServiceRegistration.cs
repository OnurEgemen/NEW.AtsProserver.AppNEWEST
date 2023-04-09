using AtsProServer.App.Application.Mappings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AtsProServer.App.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new CategoryProfile(),
                    new VehicleProfile(),
                    new AppUserProfile()
                });
            });
        }
    }
}
