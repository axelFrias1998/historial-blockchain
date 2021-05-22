using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class noKeyEnMuchosAMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalDoctor",
                table: "HospitalDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalAdministrador",
                table: "HospitalAdministrador");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "248896d5-a23c-4056-8d08-2cf085bfe879");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3367cc01-cd66-475e-89b2-8bbc7e8d76e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d52774-d3d1-4355-ab16-777d9ad43708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c13591a7-9551-4566-ac7b-0141cb05ca33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca7ae0eb-1dff-4e07-b654-64420bc8dc4a");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalAdministrador",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "HospitalAdministrador",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c2e2f8b7-bf31-4966-b805-943984d4114e", "80cbd1a5-75d6-4edd-abf3-b2607d7c9fbb", "SysAdmin", "SysAdmin" },
                    { "128808ae-065b-4f85-95e7-b3f61d7df5f2", "edbc2fec-d350-480c-afc6-7e1ffd702cf8", "PacsAdmin", "PacsAdmin" },
                    { "fcb092e5-e0d9-46e9-a36e-85844cc0a829", "ebcf809d-e501-4412-80e7-98470bf680be", "ClinicAdmin", "ClinicAdmin" },
                    { "481f42dc-a4b7-4693-9011-ac29b332891d", "a66dd545-cb8a-4818-899c-15d931675124", "Pacient", "Pacient" },
                    { "6ab79905-b757-4956-b573-5ae70f93fbec", "c6698f74-26e0-49b6-ad16-27310ca4842a", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEspecialidades_EspecialidadId",
                table: "HospitalEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctor_DoctorId",
                table: "HospitalDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAdministrador_AdminId",
                table: "HospitalAdministrador",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HospitalEspecialidades_EspecialidadId",
                table: "HospitalEspecialidades");

            migrationBuilder.DropIndex(
                name: "IX_HospitalDoctor_DoctorId",
                table: "HospitalDoctor");

            migrationBuilder.DropIndex(
                name: "IX_HospitalAdministrador_AdminId",
                table: "HospitalAdministrador");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "128808ae-065b-4f85-95e7-b3f61d7df5f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481f42dc-a4b7-4693-9011-ac29b332891d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab79905-b757-4956-b573-5ae70f93fbec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e2f8b7-bf31-4966-b805-943984d4114e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb092e5-e0d9-46e9-a36e-85844cc0a829");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalAdministrador",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "HospitalAdministrador",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades",
                columns: new[] { "EspecialidadId", "HospitalId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalDoctor",
                table: "HospitalDoctor",
                columns: new[] { "DoctorId", "HospitalId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalAdministrador",
                table: "HospitalAdministrador",
                columns: new[] { "AdminId", "HospitalId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5d52774-d3d1-4355-ab16-777d9ad43708", "59607257-135b-4a41-826b-af78f22ae4c3", "SysAdmin", "SysAdmin" },
                    { "3367cc01-cd66-475e-89b2-8bbc7e8d76e0", "dc4bd7cb-2318-447c-8baf-c8aeb64f07da", "PacsAdmin", "PacsAdmin" },
                    { "ca7ae0eb-1dff-4e07-b654-64420bc8dc4a", "9075c22c-5c1f-4a70-b5bc-d9a11d07234d", "ClinicAdmin", "ClinicAdmin" },
                    { "c13591a7-9551-4566-ac7b-0141cb05ca33", "04022cd3-7696-4bc7-a790-deb6d87666ed", "Pacient", "Pacient" },
                    { "248896d5-a23c-4056-8d08-2cf085bfe879", "a5214c27-0f96-49a1-97bb-600fd87297c4", "Doctor", "Doctor" }
                });
        }
    }
}
