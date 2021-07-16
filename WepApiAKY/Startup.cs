using BL.Abstract;
using BL.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiAKY
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WepApiAKY", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });

            services.AddScoped<IAmaclarService, AmaclarService >();
            services.AddScoped<IHedeflerServices, HedeflerServices>();
            services.AddScoped<IPerformanslarServices, PerformansService>();
            services.AddScoped<IIsturleriServices, IsTuruService>();
            services.AddScoped<IAraclarServices, AraclarService>();
            services.AddScoped<IBirimServis, BirimlerService>();
            services.AddScoped<IBirimTipleriServices, BirimTipiService>();
            services.AddScoped<IDonanimServices, DonanimService>();
            services.AddScoped<IFaaliyetServices, FaaliyetService>();
            services.AddScoped<IFizikselYapilarServices, FizikselYapilarService>();
            services.AddScoped<IIslerServices, IsService>();
            services.AddScoped<IKullaniciServices, KullaniciService>();
            services.AddScoped<IKullaniciBirimlerServices, KullaniciBirimiService>();
            services.AddScoped<IMervzuatlarServices, MevzuatlarService>();
            services.AddScoped<IOlcuBirimiServices, OlcuBirimiService>();
            services.AddScoped<IPersonellerServices, PersonelService>();
            services.AddScoped<IStratejiYiliServices,StratejiYiliService >();
            services.AddScoped<IYazilimlarServices, YazilimService>();
            services.AddScoped<IYetkiGorevTanimlariServices, YetkiGorevTanimService>();
            services.AddScoped<IYetkiGruplariServices, YetkiGruplariService>();
            services.AddScoped<IYetkilerServices, YetkiService>();
            services.AddScoped<IYillikHedefServices, YillikHedefService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WepApiAKY v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseDeveloperExceptionPage();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
