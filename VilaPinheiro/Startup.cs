﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VilaPinheiro.Services.Abstract;
using VilaPinheiro.Services.Concrete;

namespace VilaPinheiro
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
            #region Injeção de Dependencia dos Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            #endregion

            #region Injeção de Dependencia dos Services
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IPersonService, PersonService>();
            #endregion

            services.AddControllers();
            services.AddMvc( c =>
            {
                c.EnableEndpointRouting = false;
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Vila Pinheiro API",
                    Description = "APIs para o aplicativo de informativos da Vila Pinheiro",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Dimitri Carvalho Menezes",
                        Email = "dimitri.menezes@gmail.com"                        
                    }
                });

            });
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

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI( c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vila Pinheiro API");            
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
