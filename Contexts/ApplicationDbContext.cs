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
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<ServicesCatalog> ServicesCatalog { get; set; }
        public DbSet<SpecialitiesCatalog> SpecialitiesCatalog { get; set; }


        //public DbSet<Consulta> Consulta { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region SpecialitiesCatalog
            var pediatria = new SpecialitiesCatalog(){
                Id = 1,
                Type = "Pediatría"
            };
            builder.Entity<SpecialitiesCatalog>().HasData(pediatria);

            var ginecologia = new SpecialitiesCatalog(){
                Id = 2,
                Type = "Ginecología"
            };
            builder.Entity<SpecialitiesCatalog>().HasData(ginecologia);

            var geriatria = new SpecialitiesCatalog(){
                Id = 3,
                Type = "Geriatría"
            };
            builder.Entity<SpecialitiesCatalog>().HasData(geriatria);

            var odontologia = new SpecialitiesCatalog(){
                Id = 4,
                Type = "Odontología"
            };
            builder.Entity<SpecialitiesCatalog>().HasData(odontologia);

            var general = new SpecialitiesCatalog(){
                Id = 5,
                Type = "General"
            };
            builder.Entity<SpecialitiesCatalog>().HasData(general);
            #endregion
            
            #region ServiceCatalog
            var publicHospital = new ServicesCatalog(){
                Id = 1,
                Type = "Hospital público",
                IsPublic = true
            };
            builder.Entity<ServicesCatalog>().HasData(publicHospital);

            var privateHospital = new ServicesCatalog(){
                Id = 2,
                Type = "Hospital privado",
                IsPublic = false
            };
            builder.Entity<ServicesCatalog>().HasData(privateHospital);

            var publicClinic = new ServicesCatalog(){
                Id = 3,
                Type = "Clínica pública",
                IsPublic = true
            };
            builder.Entity<ServicesCatalog>().HasData(publicClinic);

            var privateClinic = new ServicesCatalog(){
                Id = 4,
                Type = "Clínica privada",
                IsPublic = false
            };
            builder.Entity<ServicesCatalog>().HasData(privateClinic);
            #endregion
            
            #region IdentityRole
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
            #endregion
      
            #region HospitalConfiguration
            builder.Entity<Hospital>()
                .HasOne(x => x.Admin)
                .WithOne(x => x.HospitalAdmin)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Hospital>()
                .HasMany(x => x.Doctors)
                .WithMany(x => x.Hospitals)
                .UsingEntity<HospitalDoctor>(
                    x => x.HasOne(x => x.Doctor)
                        .WithMany().HasForeignKey(x => x.DoctorId),
                    x => x.HasOne(x => x.Hospital)
                        .WithMany().HasForeignKey(x => x.HospitalId)
                );

            builder.Entity<Hospital>()
                .HasMany(x => x.Especialidades)
                .WithMany(x => x.Hospitals)
                .UsingEntity<HospitalEspecialidad>(
                    x => x.HasOne(x => x.Especialidad)
                        .WithMany().HasForeignKey(x => x.EspecialidadId),
                    x => x.HasOne(x => x.Hospital)
                        .WithMany().HasForeignKey(x => x.HospitalId)                   
                );
            
            builder.Entity<Hospital>()
                .HasMany(x => x.Consultas)
                .WithMany(x => x.Hospitals)
                .UsingEntity<HospitalConsulta>(
                    x => x.HasOne(x => x.Consulta)
                        .WithMany().HasForeignKey(x => x.ConsultaId),
                    x => x.HasOne(x => x.Hospital)
                        .WithMany().HasForeignKey(x => x.HospitalId)                   
                );
            #endregion
            
            base.OnModelCreating(builder);
        }
    }
}