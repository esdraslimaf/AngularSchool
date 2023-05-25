using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AngularSchool.API.Database;
using AngularSchool.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace AngularSchool.API
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
            services.AddDbContext<SchoolContext>(
                context=>context.UseSqlite(Configuration.GetConnectionString("MyConnection")));

            services.AddScoped<IRepository, Repository>();

            services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("AngularSchoolAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "AngularSchool API",
                    Version = "1.0",
                    Description = "Projeto de CRUD API que utilizará Angular",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Esdras Lima",
                        Url = new Uri("https://github.com/esdraslimaf")
                    }
                }); 

                var arquivocomentarioxml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var caminhodoarquivodecomentariosxml = Path.Combine(AppContext.BaseDirectory, arquivocomentarioxml);
                options.IncludeXmlComments(caminhodoarquivodecomentariosxml);
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/AngularSchoolAPI/swagger.json", "AngularSchoolApi");
                options.RoutePrefix = "";
            });
      
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}