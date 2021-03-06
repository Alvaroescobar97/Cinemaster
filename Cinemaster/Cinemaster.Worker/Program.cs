using AutoMapper;
using Cinemaster.Application.Ports;
using Cinemaster.Domain.Ports;
using Cinemaster.Domain.Services;
using Cinemaster.Infrastructure;
using Cinemaster.Infrastructure.Adapters;
using Cinemaster.Infrastructure.Extensions;
using Cinemaster.Infrastructure.HealthChecks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cinemaster.Worker
{
    public class Program
    {

        protected Program()
        {

        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapHealthChecks("/health", new HealthCheckOptions
                            {
                                AllowCachingResponses = false
                            });
                        });
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var executingAssembly = typeof(Program).Assembly;
                    services.AddMediatR(Assembly.Load("Cinemaster.Application"), executingAssembly);
                    var applicationAssembly = executingAssembly.GetReferencedAssemblies()
                        .FirstOrDefault(x => x.Name.Equals("Cinemaster.Application", System.StringComparison.InvariantCulture));


                    services.AddAutoMapper(Assembly.Load(applicationAssembly.FullName));
                    var JsonConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", false).Build();



                    services.AddDbContext<Infrastructure.PersistenceContext>(opt =>
                    {
                        opt.UseSqlServer(hostContext.Configuration.GetConnectionString("database"), sqlopts =>
                        {
                            sqlopts.MigrationsHistoryTable("_MigrationHistory", hostContext.Configuration.GetValue<string>("SchemaName"));
                        });
                    });

                    services.AddHealthChecks()
                    .AddCheck<BrokerHealthCheck>("Broker Test")
                    .AddDbContextCheck<PersistenceContext>();

                    services.AddSingleton(c => JsonConfig);
                    services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                    services.AddTransient<IPersonService, PersonService>();
                    services.AddTransient<IRabbitMessaging, MessagingAdapter>();
                    services.AddHostedService<Worker>();
                    services.AddRabbitSupport(JsonConfig);
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .ReadFrom.Configuration(hostContext.Configuration)
                        .WriteTo.File($"{typeof(Program).Assembly.GetName().Name}.log", rollingInterval: RollingInterval.Day)
                        .WriteTo.Console()
                        .CreateLogger();
                });
    }
}


