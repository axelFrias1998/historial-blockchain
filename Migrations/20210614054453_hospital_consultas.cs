using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class hospital_consultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");
            
            migrationBuilder.CreateTable(
                name: "HospitalConsulta",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalConsulta", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_HospitalConsulta_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalConsulta_AspNetUsers_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalConsulta_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalConsulta_DoctorId",
                table: "HospitalConsulta",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalConsulta_HospitalId",
                table: "HospitalConsulta",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalConsulta_PacienteId",
                table: "HospitalConsulta",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalConsulta");

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diferenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Dolencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Educacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hallazgos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlanTerapeutico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problemas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pruebas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PruebasDiagnosticas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Razonamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelacionPasada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
        }
    }
}
