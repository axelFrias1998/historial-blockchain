using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class consulta_medicamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoGrupoMedicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoGrupoMedicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialitiesCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialitiesCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceCatalogId = table.Column<int>(type: "int", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospitals_ServicesCatalog_ServiceCatalogId",
                        column: x => x.ServiceCatalogId,
                        principalTable: "ServicesCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Dolencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelacionPasada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hallazgos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PruebasDiagnosticas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problemas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diferenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Razonamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pruebas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanTerapeutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Educacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seguimiento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consultas_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_AspNetUsers_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalAdministrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAdministrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDoctor",
                columns: table => new
                {
                    HospitalDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDoctor", x => x.HospitalDoctorId);
                    table.ForeignKey(
                        name: "FK_HospitalDoctor_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalDoctor_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalDoctor_SpecialitiesCatalog_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "SpecialitiesCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalEspecialidades_SpecialitiesCatalog_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "SpecialitiesCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalMedicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViaAdministracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoMedicamentosId = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Precauciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EfectosSecundarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMedicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalMedicamentos_CatalogoGrupoMedicamentos_GrupoMedicamentosId",
                        column: x => x.GrupoMedicamentosId,
                        principalTable: "CatalogoGrupoMedicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalMedicamentos_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4c62a1f-9361-4735-a6b0-3e3c880d1356", "3a591f57-fa53-44b7-a5e7-04f0e7d72c9e", "SysAdmin", "SysAdmin" },
                    { "79d33e5e-6626-4c94-a834-d748d864f27f", "47021859-5cb7-44fb-8226-b89264ddd4bf", "PacsAdmin", "PacsAdmin" },
                    { "9b57a0d3-b291-4ef2-a3e7-9bf0513053f9", "5cd9fb33-b10b-46c3-873e-f3f3472c1b9d", "ClinicAdmin", "ClinicAdmin" },
                    { "ed41340d-9716-4886-9ac9-ecb48ad93716", "a3858ee2-fddc-4663-8d66-4e8a00d30132", "Pacient", "Pacient" },
                    { "8d19ee12-f737-4580-829c-33f712f19389", "0f7ef1ad-de4f-4ac9-aefb-f070de432929", "Doctor", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "CatalogoGrupoMedicamentos",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 8, "Gastroenterología" },
                    { 7, "Enfermedades Inmunoalérgicas" },
                    { 5, "Endocrinología y metabolismo" },
                    { 6, "Enfermedades Infecciosas y Parasitarias" },
                    { 3, "Cardiología" },
                    { 2, "Anestesia" },
                    { 1, "Analgesia" },
                    { 4, "Dermatología" }
                });

            migrationBuilder.InsertData(
                table: "ServicesCatalog",
                columns: new[] { "Id", "IsPublic", "Type" },
                values: new object[,]
                {
                    { 1, true, "Hospital público" },
                    { 2, false, "Hospital privado" },
                    { 3, true, "Clínica pública" },
                    { 4, false, "Clínica privada" }
                });

            migrationBuilder.InsertData(
                table: "SpecialitiesCatalog",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 4, "Odontología" },
                    { 1, "Pediatría" },
                    { 2, "Ginecología" },
                    { 3, "Geriatría" },
                    { 5, "General" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_DoctorId",
                table: "Consultas",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_HospitalId",
                table: "Consultas",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAdministrador_AdminId",
                table: "HospitalAdministrador",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAdministrador_HospitalId",
                table: "HospitalAdministrador",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctor_DoctorId",
                table: "HospitalDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctor_EspecialidadId",
                table: "HospitalDoctor",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctor_HospitalId",
                table: "HospitalDoctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEspecialidades_EspecialidadId",
                table: "HospitalEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEspecialidades_HospitalId",
                table: "HospitalEspecialidades",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMedicamentos_GrupoMedicamentosId",
                table: "HospitalMedicamentos",
                column: "GrupoMedicamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMedicamentos_HospitalId",
                table: "HospitalMedicamentos",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_ServiceCatalogId",
                table: "Hospitals",
                column: "ServiceCatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "HospitalAdministrador");

            migrationBuilder.DropTable(
                name: "HospitalDoctor");

            migrationBuilder.DropTable(
                name: "HospitalEspecialidades");

            migrationBuilder.DropTable(
                name: "HospitalMedicamentos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SpecialitiesCatalog");

            migrationBuilder.DropTable(
                name: "CatalogoGrupoMedicamentos");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "ServicesCatalog");
        }
    }
}
