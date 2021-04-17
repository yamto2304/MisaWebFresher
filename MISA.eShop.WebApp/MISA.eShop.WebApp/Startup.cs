using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.eShop.Core.Interfaces;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;
using MISA.eShop.Core.Services;
using MISA.eShop.Infrastructure.Repository;
using System;

namespace MISA.eShop.WebApp
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
            services.AddCors(); //add cors
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk", Version = "v1" });
            });
            //add scoped
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IWardService, WardService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk v1"));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromMinutes(10)));

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
