using System;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
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