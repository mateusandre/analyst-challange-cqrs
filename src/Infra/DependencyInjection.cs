using Domain.Entities;
using Infra.Context;
using Infra.Repository;
using Infra.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, Infra.UnitOfWork.UnitOfWork>();
            services.AddScoped<IRepository<SensorEvent>, Repository<SensorEvent>>();
            services.AddDbContext<AnalystChallangeContext>(options => options.UseSqlServer(configuration.GetConnectionString("AnalystChallangeContext")));

            return services;
        }
    }
}
