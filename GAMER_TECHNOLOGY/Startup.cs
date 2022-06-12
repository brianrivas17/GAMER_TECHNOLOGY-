using Blazored.LocalStorage;
using Blazored.Toast;
using GAMER_TECHNOLOGY.Areas.Identity;
using GAMER_TECHNOLOGY.Data;
using GAMER_TECHNOLOGY.Data.PDF;
using GAMER_TECHNOLOGY.Data.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMER_TECHNOLOGY
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddBlazoredLocalStorage();
            //registro de interfaz
            
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICarritoService, CarritoService>();
            services.AddScoped<ICalificacionService, CalificacionService>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<IDevolucionService, DevolucionService>();
            services.AddScoped<IFacturaPDF, FacturaPDF>();
            services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();
            services.AddBlazoredToast();
            //Conexion DB
            var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDBContext"));
            //Patron Singleton
            services.AddSingleton(SqlConnectionConfiguration);

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
