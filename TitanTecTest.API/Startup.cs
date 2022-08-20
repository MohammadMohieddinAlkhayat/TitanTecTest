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
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanTecTest.BL.Results;
using TitanTecTest.BL.Services.Employees.Dtos;
using TitanTecTest.BL.Services.Mappers;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL;
using TitanTecTest.DAL.Models;
using TitanTecTest.DAL.Repositories.CRepositories;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private static IMapper _mapper = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ModelAutoMapperProfile());
            mc.CreateMap<CreateEmployeeDto, Employee>();
            mc.CreateMap<UpdateEmployeeDto, Employee>();
            mc.CreateMap<Employee, EmployeeResult>()
            .ForMember(dest=>dest.Files,opt=>opt.MapFrom(src=>src.Files.Select(x=>x.Name)));
            mc.CreateMap<List<Employee>, ListResult<EmployeeResult>>()
              .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        }).CreateMapper();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IServicePool, ServicePool>();
            services.AddSingleton(_mapper);
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TitanTecTest.API", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TitanTecTest.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
