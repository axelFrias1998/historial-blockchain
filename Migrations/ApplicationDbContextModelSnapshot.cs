﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using historial_blockchain.Contexts;

namespace historial_blockchain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "4d2fa19e-4563-4c87-a382-9b67c086d117",
                            ConcurrencyStamp = "bf8e5901-1014-4d84-9d45-dc9923bba7e6",
                            Name = "SysAdmin",
                            NormalizedName = "SysAdmin"
                        },
                        new
                        {
                            Id = "0feb0fe4-bd75-46b6-a801-7096b99daf05",
                            ConcurrencyStamp = "0bd8dcfc-9e98-4e81-b38c-428f141e1a3c",
                            Name = "PacsAdmin",
                            NormalizedName = "PacsAdmin"
                        },
                        new
                        {
                            Id = "9ca74fdb-2285-4e81-bca6-242c6f4731e0",
                            ConcurrencyStamp = "03d979ad-7dd3-4f2c-a757-1b8ae1d84c86",
                            Name = "ClinicAdmin",
                            NormalizedName = "ClinicAdmin"
                        },
                        new
                        {
                            Id = "a9d3cf77-ac36-4d02-bb74-d7651485a632",
                            ConcurrencyStamp = "2d201d41-d29e-4246-a325-ef43ae78a750",
                            Name = "Pacient",
                            NormalizedName = "Pacient"
                        },
                        new
                        {
                            Id = "1e337817-079b-4bbf-a4c8-658d15947f4f",
                            ConcurrencyStamp = "e3ae400b-162f-402a-9d93-0d9eb1429fb5",
                            Name = "Doctor",
                            NormalizedName = "Doctor"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("historial_blockchain.Entities.Consulta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PacienteId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("historial_blockchain.Entities.Hospital", b =>
                {
                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceCatalogId")
                        .HasColumnType("int");

                    b.HasKey("HospitalId");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.HasIndex("ServiceCatalogId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalConsulta", b =>
                {
                    b.Property<string>("ConsultaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConsultaId", "HospitalId");

                    b.HasIndex("HospitalId");

                    b.ToTable("HospitalConsulta");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalDoctor", b =>
                {
                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "HospitalId");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("HospitalId");

                    b.ToTable("HospitalDoctor");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalEspecialidad", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("HospitalId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EspecialidadId", "HospitalId");

                    b.HasIndex("HospitalId");

                    b.ToTable("HospitalEspecialidades");
                });

            modelBuilder.Entity("historial_blockchain.Entities.ServicesCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServicesCatalog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsPublic = true,
                            Type = "Hospital público"
                        },
                        new
                        {
                            Id = 2,
                            IsPublic = false,
                            Type = "Hospital privado"
                        },
                        new
                        {
                            Id = 3,
                            IsPublic = true,
                            Type = "Clínica pública"
                        },
                        new
                        {
                            Id = 4,
                            IsPublic = false,
                            Type = "Clínica privada"
                        });
                });

            modelBuilder.Entity("historial_blockchain.Entities.SpecialitiesCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpecialitiesCatalog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Pediatría"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Ginecología"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Geriatría"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Odontología"
                        },
                        new
                        {
                            Id = 5,
                            Type = "General"
                        });
                });

            modelBuilder.Entity("historial_blockchain.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("historial_blockchain.Entities.Consulta", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("historial_blockchain.Models.ApplicationUser", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.Navigation("Doctor");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("historial_blockchain.Entities.Hospital", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", "Admin")
                        .WithOne("HospitalAdmin")
                        .HasForeignKey("historial_blockchain.Entities.Hospital", "AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Entities.ServicesCatalog", "ServicesCatalog")
                        .WithMany()
                        .HasForeignKey("ServiceCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("ServicesCatalog");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalConsulta", b =>
                {
                    b.HasOne("historial_blockchain.Entities.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Entities.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalDoctor", b =>
                {
                    b.HasOne("historial_blockchain.Models.ApplicationUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Entities.SpecialitiesCatalog", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Entities.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Especialidad");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("historial_blockchain.Entities.HospitalEspecialidad", b =>
                {
                    b.HasOne("historial_blockchain.Entities.SpecialitiesCatalog", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("historial_blockchain.Entities.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("historial_blockchain.Models.ApplicationUser", b =>
                {
                    b.Navigation("HospitalAdmin");
                });
#pragma warning restore 612, 618
        }
    }
}
