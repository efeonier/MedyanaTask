using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyana.API.Extentions;
using Medyana.API.Filters;
using Medyana.API.Model;
using Medyana.Core.Entity;
using Medyana.Core.Repositories;
using Medyana.Core.Services;
using Medyana.Core.UnitOfWorks;
using Medyana.Data;
using Medyana.Data.Repositories;
using Medyana.Data.UnitOfWorks;
using Medyana.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Medyana.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        private readonly ILogger _logger;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddDbContext<MedyanaDbContext>(opt =>
            {
                opt.UseSqlServer(_configuration.GetConnectionString("SqlConStr"),
                    o => { o.MigrationsAssembly("Medyana.Data"); });
            });


            //transient = herseferinde farklı nesne üretir
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //addscoped = mevcut nesneyi kullanır 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IPatientService, PatientService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Medyana.API", Version = "v1"});
            });

            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medyana.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            loggerFactory.AddFile(_configuration.GetSection("SeriLogNameFormat").GetValue<string>("FilePath"));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseCustomException();
        }
    }
}