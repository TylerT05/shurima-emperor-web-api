using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Leagues.Interfaces;
using ShurimaEmperor.Api.Leagues.Services;

namespace ShurimaEmperor.Api.Leagues
{
    public class Startup
    {
        private const string API_KEY = "RGAPI-ffc0bf78-a26d-4ecc-84a1-05fdef2e8d73";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILeaguesService, LeaguesService>();
            services.AddHttpClient("LeaguesService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:RiotGamesApi"]);
                config.DefaultRequestHeaders.Add("X-Riot-Token", API_KEY);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
