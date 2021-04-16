using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MISA.eShop.WebApp.Extensions;

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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.eShop.WebApp", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.Api", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.eShop.WebApp v1"));
            }
            // X? lý Exception
            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;

            //    if (exception is ValidateExceptions)
            //    {
            //        var responseBadRequest = new
            //        {
            //            devMsg = exception.Message,
            //            userMsg = "Có l?i x?y ra, vui lòng liên h? MISA ?? ???c tr? giúp!",
            //            errorCode = "misa-400",
            //            moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //            traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //        };
            //        context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //        await context.Response.WriteAsJsonAsync(responseBadRequest);
            //    }

            //    var response = new
            //    {
            //        devMsg = exception.Message,
            //        userMsg = "Có l?i x?y ra, vui lòng liên h? MISA ?? ???c tr? giúp!",
            //        errorCode = "misa-005",
            //        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //    };

            //    await context.Response.WriteAsJsonAsync(response);
            //}));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
