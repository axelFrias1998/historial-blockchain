using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class cambioConexion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b26070f-49df-46f7-88b2-6d5945284dc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a48973b-59ba-4770-a80d-e52206c36ddf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76d14537-a2f9-43af-88de-085178566ff2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c834067f-cead-4915-9c17-0d9714102fdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e411d73d-ce17-4809-a982-38b8ae41e12e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa4e3329-742f-48fa-b651-da3fcbab3dfd", "79393d4f-346f-4ab2-84c2-975e82caa466", "SysAdmin", "SysAdmin" },
                    { "b2c7a13c-ceed-487e-9c23-12c5af98b250", "d56b66a9-b464-4f99-8a40-e43d0ba3094f", "PacsAdmin", "PacsAdmin" },
                    { "65f8f8de-c554-419f-a1cf-8a5170c31736", "94746652-aaa5-4629-8737-8ec629c13cee", "ClinicAdmin", "ClinicAdmin" },
                    { "f1265d40-9487-4dcc-bbbd-f73aff712c1b", "e9664b85-eb11-442e-b762-c356d693e7c8", "Pacient", "Pacient" },
                    { "cbbadc36-9c49-4dae-9382-5f9a698e0c15", "39da105b-7c3f-46c6-9777-699e5e19275c", "Doctor", "Doctor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f8f8de-c554-419f-a1cf-8a5170c31736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa4e3329-742f-48fa-b651-da3fcbab3dfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2c7a13c-ceed-487e-9c23-12c5af98b250");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbbadc36-9c49-4dae-9382-5f9a698e0c15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1265d40-9487-4dcc-bbbd-f73aff712c1b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a48973b-59ba-4770-a80d-e52206c36ddf", "21871d31-83de-45e7-9071-aabd13fad1ac", "SysAdmin", "SysAdmin" },
                    { "c834067f-cead-4915-9c17-0d9714102fdf", "3422586d-0f84-4864-b79c-0a1b9bd85324", "PacsAdmin", "PacsAdmin" },
                    { "2b26070f-49df-46f7-88b2-6d5945284dc2", "fed665c2-b13d-4de8-8c59-9cc8e9bd4f3f", "ClinicAdmin", "ClinicAdmin" },
                    { "e411d73d-ce17-4809-a982-38b8ae41e12e", "75cb6837-688d-4d0b-9927-bdaf85e0d089", "Pacient", "Pacient" },
                    { "76d14537-a2f9-43af-88de-085178566ff2", "4ce71a94-eaba-415e-87a1-e9eedacd9838", "Doctor", "Doctor" }
                });
        }
    }
}
