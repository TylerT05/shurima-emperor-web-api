using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Matches.Interfaces;
using ShurimaEmperor.Api.Matches.Services;

namespace ShurimaEmperor.Api.Matches
{
    public class Startup
    {
        private const string API_KEY = "RGAPI-513a6bc3-378f-4ce3-907e-fd298ea23fd8";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMatchesService, MatchesService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpClient("MatchesService", config =>
            {
                //config.BaseAddress = new Uri(Configuration["Services:RiotGamesApi"]);
                config.DefaultRequestHeaders.Add("X-Riot-Token", API_KEY);
            });
            services.AddCors(c =>
            {
                c.AddDefaultPolicy(options => options.AllowAnyOrigin());
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
