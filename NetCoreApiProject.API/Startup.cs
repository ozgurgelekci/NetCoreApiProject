using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCoreApiProject.API.Extensions;
using NetCoreApiProject.API.Filters;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Core.Services;
using NetCoreApiProject.Core.UnitOfWorks;
using NetCoreApiProject.Data.DbContexts;
using NetCoreApiProject.Data.Repositories;
using NetCoreApiProject.Data.UnitOfWorks;
using NetCoreApiProject.Service.Services;

namespace NetCoreApiProject.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(NotFoundFilter<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString:SqlConStr"].ToString(),
                    o => o.MigrationsAssembly("NetCoreApiProject.Data"));
            });

            #region Swagger Xml 

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = ".NET Core API",
                    Description = "Kategoriler ve Ürünlere ait CRUD iþlemlerinin gerçekleþtirildiði API. Örnek olmasý için Categories endpointlerinde bilgiler verilmiþtir.",
                    Contact = new OpenApiContact
                    {
                        Name = "Özgür Gelekçi",
                        Email = "ozgurgelekci@gmail.com",
                        Url = new Uri("http://www.ozgurgelekci.com")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                gen.IncludeXmlComments(xmlPath);
            });

            #endregion

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Core API");
            });

            #endregion


            // Custom Exception Handler
            app.UseCustomException();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
