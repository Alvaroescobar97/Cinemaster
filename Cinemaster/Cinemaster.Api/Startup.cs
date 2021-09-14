using AutoMapper;
using Cinemaster.Api.Extensions;
using Cinemaster.Api.Filters;
using Cinemaster.Application.Ports;
using Cinemaster.Infrastructure.Adapters;
using Cinemaster.Infrastructure.Extensions;
using Cinemaster.Infrastructure.HealthChecks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Cinemaster.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(Assembly.Load("Cinemaster.Application"), typeof(Startup).Assembly);

            var applicationAssemblyName = typeof(Startup).Assembly.GetReferencedAssemblies()
                .FirstOrDefault(x => x.Name.Equals("Cinemaster.Application", StringComparison.InvariantCulture));

            services.AddAutoMapper(Assembly.Load(applicationAssemblyName.FullName));

            services.AddDbContext<Infrastructure.PersistenceContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("database"), sqlopts =>
                {
                    sqlopts.MigrationsHistoryTable("_MigrationHistory", Configuration.GetValue<string>("SchemaName"));
                });
            });

            services.AddRabbitSupport(Configuration);
            services.AddTransient<IRabbitMessaging, MessagingAdapter>();

            services.AddControllers(mvcOpts =>
            {
                mvcOpts.Filters.Add(typeof(AppExceptionFilterAttribute));
            });

            services.AddSingleton(cfg => Configuration);
            services.AddHealthChecks()
                .AddCheck<BrokerHealthCheck>("Broker Test")
                .AddDbContextCheck<Infrastructure.PersistenceContext>();

            services.LoadAppStoreRepositories();
            services.AddSwaggerDocument();

        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

        }
    }
}
