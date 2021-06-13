using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using historial_blockchain.Contexts;
using historial_blockchain.Data;
using historial_blockchain.Entities;
using historial_blockchain.Helpers;
using historial_blockchain.Models;
using historial_blockchain.Models.DTOs;
using historial_blockchain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace historial_blockchain
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
            //services.AddCors();
            services.AddScoped<HospitalAdministradoresRepository>();
            services.AddAutoMapper(Configuration => 
            {
                Configuration.CreateMap<ApplicationUser, CreatedUserDTO>();
                Configuration.CreateMap<Hospital, CreatedHospitalDTO>();
                Configuration.CreateMap<Hospital, HospitalsDTO>();
                Configuration.CreateMap<ServicesCatalog, ServicesCatalogDTO>();
                Configuration.CreateMap<SpecialitiesCatalog, SpecialitiesDTO>();
                Configuration.CreateMap<HospitalSpecialitiesDTO, HospitalEspecialidad>().ReverseMap();
                Configuration.CreateMap<HospitalSpeciality, HospitalEspecialidad>().ReverseMap();
                Configuration.CreateMap<HospitalAdmin, HospitalAdministrador>().ReverseMap();
                Configuration.CreateMap<CatalogoGrupoMedicamentos, ListadoGrupoMedicamentosDTO>();
                Configuration.CreateMap<HospitalMedicamentosCreateDTO, HospitalMedicamentos>().ReverseMap();
                Configuration.CreateMap<HospitalMedicamentosUpdateDTO, HospitalMedicamentos>().ReverseMap();
            } ,typeof(Startup));
            services.AddScoped<HashService>();
            services.AddDataProtection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                options.User.RequireUniqueEmail = true;
            });

            services.AddControllers(options => 
                {
                    options.Filters.Add(typeof(FiltroErrores));
                })
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
                    ClockSkew = TimeSpan.Zero

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "historial_blockchain", Version = "v1" });
            });
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "historial_blockchain v1"));
            }

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "historial_blockchain v1"));
            app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseCors(builder => builder.WithOrigins("https://localhost:5001"));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
