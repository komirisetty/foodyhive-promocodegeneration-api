using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WellsFargo.Libraries.DataAccess.Impl;
using WellsFargo.Libraries.DataAccess.Interfaces;
using WellsFargo.Libraries.Domain.Impl;
using WellsFargo.Libraries.Domian.Interfaces;
using WellsFargo.Libraries.Hosting.Extensibility;
using WellsFargo.Libraries.ORM.Impl;
using WellsFargo.Libraries.ORM.Interfaces;using Microsoft.Extensions.PlatformAbstractions;


namespace Promo_Codo_Hosting
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
            services.AddScoped<IPromoCodeContext, PromoCodeContext>();
            services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
            services.AddScoped<IPromoCodeDoaminServices, PromoCodeDomainServices>();
            services.AddScoped<IDatabaseSettings, PromoCodeDatabaseSettings>();

            services.AddSwaggerGen(swaggerGenOption =>
            {
                swaggerGenOption.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Generate PromoCode API",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "service-ref@alphasource.com",
                        Name = "AlphaSource Engineering Team",
                        Url = new Uri(@"https://engineering.alphasource.com/promocode")
                    },
                    Description = "Simple Generate PromoCode API",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri(@"https://services.alphasource.com/license")
                    },
                    TermsOfService = new Uri(@"https://services.alphasource.com/terms")
                });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, @"WellsFargo.Libraries.Services.Impl.xml");

                swaggerGenOption.IncludeXmlComments(filePath);
            });          


            services.AddControllers();
            services.AddCors(options => options.AddPolicy("CROS",corsPolicyBuilder => 
            {
                corsPolicyBuilder.SetIsOriginAllowed(x => true)
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swaggerUIOptions =>
                swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Generate PromoCode API, v1")
            ); ;

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CROS");

            app.UseAuthorization();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
