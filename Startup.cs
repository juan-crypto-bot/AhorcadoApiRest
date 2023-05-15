using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
namespace AhorcadoApiRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HangedDbContext>(opt => opt.UseSqlServer(Configuration["DefaultConnection"]));
            services.AddTransient<IHangedService, HangedService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IWordService, WordService>();
            services.AddTransient<ILetterService, LetterService>();
            services.AddTransient<IHangedRepository, SqlServerHangedRepository>();
            services.AddTransient<ILetterRepository, SqlServerLetterRepository>();
            services.AddTransient<IWordRepository, SqlServerWordRepository>();
            services.AddTransient<IPlayerRepository, SqlServerPlayerRepository>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseLoggingMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
