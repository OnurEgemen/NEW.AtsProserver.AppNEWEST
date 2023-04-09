using AtsProServer.App.Application.Interfaces;
using AtsProServer.App.Persistance.Context;
using AtsProServer.App.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtsProServer.App.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AtsContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
    }
}
