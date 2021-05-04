using historial_blockchain.Entities;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Contexts
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
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

            base.OnModelCreating(builder);
        }
    }
}