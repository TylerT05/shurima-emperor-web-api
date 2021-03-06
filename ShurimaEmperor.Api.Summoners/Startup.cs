using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Summoners.Interfaces;
using ShurimaEmperor.Api.Summoners.Services;

namespace ShurimaEmperor.Api.Summoners
{
    public class Startup
    {
        private const string API_KEY = "RGAPI-14215bdb-6d02-4025-a42b-cb55af6d834e";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISummonersService, SummonersService>();

            services.AddHttpClient("SummonersService", config =>
            {
                //config.BaseAddress = new Uri(Configuration["Services:RiotGamesApi"]);
                config.DefaultRequestHeaders.Add("X-Riot-Token", API_KEY);
            });
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder => 
            //        {
            //            //builder.WithOrigins("https://shurimaemperorwebapp.azurewebsites.net");
            //            builder.AllowAnyOrigin();
            //        });
            //});
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

            //app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
