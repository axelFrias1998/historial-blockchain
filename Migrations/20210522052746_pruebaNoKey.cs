using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class pruebaNoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalConsulta",
                table: "HospitalConsulta");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c02722f-cd50-4436-bff8-d334ee3cb4bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a608b5-87cf-4093-aa7f-7ca28a80754d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb1ece78-a1e9-404d-a647-4bdfe6acd9b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17cc931-f799-4cef-ada3-9e4a1b3d5a47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f43b17e3-8126-42c6-9646-ae5e75bb72f3");

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

            migrationBuilder.CreateIndex(
                name: "IX_HospitalConsulta_ConsultaId",
                table: "HospitalConsulta",
                column: "ConsultaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HospitalConsulta_ConsultaId",
                table: "HospitalConsulta");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalConsulta",
                table: "HospitalConsulta",
                columns: new[] { "ConsultaId", "HospitalId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d1a608b5-87cf-4093-aa7f-7ca28a80754d", "b3f75bdd-0b6e-4b48-aac7-23f4897ce68b", "SysAdmin", "SysAdmin" },
                    { "f17cc931-f799-4cef-ada3-9e4a1b3d5a47", "cd260677-ba7c-4982-8b81-42b2f7317938", "PacsAdmin", "PacsAdmin" },
                    { "eb1ece78-a1e9-404d-a647-4bdfe6acd9b3", "de7b8441-7ba1-4bfc-8f37-bc7d34a5b7ac", "ClinicAdmin", "ClinicAdmin" },
                    { "8c02722f-cd50-4436-bff8-d334ee3cb4bf", "b7157334-092b-45a2-8528-6beb2132990b", "Pacient", "Pacient" },
                    { "f43b17e3-8126-42c6-9646-ae5e75bb72f3", "dbbf0deb-a7fb-4bcc-8d0c-48fa0f7e0488", "Doctor", "Doctor" }
                });
        }
    }
}
