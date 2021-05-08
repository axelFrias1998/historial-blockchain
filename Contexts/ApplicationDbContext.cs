using System;
using historial_blockchain.Entities;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<ServicesCatalog> ServicesCatalog { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var publicHospital = new ServicesCatalog(){
                Id = 1,
                Type = "Hospital",
                IsPublic = true
            };
            builder.Entity<ServicesCatalog>().HasData(publicHospital);

            var privateHospital = new ServicesCatalog(){
                Id = 2,
                Type = "Hospital",
                IsPublic = false
            };
            builder.Entity<ServicesCatalog>().HasData(privateHospital);

            var publicClinic = new ServicesCatalog(){
                Id = 3,
                Type = "Clínica",
                IsPublic = true
            };
            builder.Entity<ServicesCatalog>().HasData(publicClinic);

            var privateClinic = new ServicesCatalog(){
                Id = 4,
                Type = "Clínica",
                IsPublic = false
            };
            builder.Entity<ServicesCatalog>().HasData(privateClinic);
            
            var sysAdmin = new IdentityRole(){
                Id = Guid.NewGuid().ToString(),
                Name = "SysAdmin",
                NormalizedName = "SysAdmin"
            };
            builder.Entity<IdentityRole>().HasData(sysAdmin);

            var pacsAdmin = new IdentityRole(){
                Id = Guid.NewGuid().ToString(),
                Name = "PacsAdmin",
                NormalizedName = "PacsAdmin"
            };
            builder.Entity<IdentityRole>().HasData(pacsAdmin);

            var clinicAdmin = new IdentityRole(){
                Id = Guid.NewGuid().ToString(),
                Name = "ClinicAdmin",
                NormalizedName = "ClinicAdmin"
            };
            builder.Entity<IdentityRole>().HasData(clinicAdmin);

            var pacient = new IdentityRole(){
                Id = Guid.NewGuid().ToString(),
                Name = "Pacient",
                NormalizedName = "Pacient"
            };
            builder.Entity<IdentityRole>().HasData(pacient);

            var doctor = new IdentityRole(){
                Id = Guid.NewGuid().ToString(),
                Name = "Doctor",
                NormalizedName = "Doctor"
            };
            builder.Entity<IdentityRole>().HasData(doctor);

            base.OnModelCreating(builder);
        }
    }
}