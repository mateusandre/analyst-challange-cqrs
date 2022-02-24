using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web.UI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var dbContext = services.GetRequiredService<AnalystChallangeContext>();
                if (dbContext.Database.IsSqlServer())
                {
                    dbContext.Database.Migrate();                    

                    if (!dbContext.Evento.Any())
                    {
                        await dbContext.Evento.AddRangeAsync(
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.sudeste.sensor01",
                                Valor = "1"
                            },
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.sudeste.sensor02",
                                Valor = "teste"
                            },
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.norte.sensor01",
                                Valor = "1"
                            },
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.nordeste.sensor01",
                                Valor = "1"
                            },
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.sul.sensor01",
                                Valor = "1"
                            },
                            new Domain.Entities.SensorEvent
                            {
                                Timestamp = 1539112021301,
                                Tag = "brasil.centro_oeste.sensor01",
                                Valor = "1"
                            }
                        );

                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                throw;
            }



            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
