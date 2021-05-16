using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class pruebaMigracionesForzadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3313023a-0ba4-4289-bc5b-391923bfd40c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba980cd-9f27-4ce5-af83-4c4028a22efa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bc64da-7c47-4267-8314-e1b9d738bcd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cccd40b3-4b72-4e88-a2fd-4f68eeb4c1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd0f0e3b-34a9-436c-9ab3-a18cdf88df5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d9d7a892-da98-4937-8500-77251882a5c7", "215381ce-39a6-4d7b-b8f0-bdf55ca2e684", "SysAdmin", "SysAdmin" },
                    { "03905782-71c8-4e18-81de-fda02e20636d", "6eb7a32b-8d97-4f36-b669-cdacd072c290", "PacsAdmin", "PacsAdmin" },
                    { "48e48a9d-7de1-469d-b0a1-46c71a805a9a", "3a1acb2f-8b79-4fe3-9165-27e9a09e76a0", "ClinicAdmin", "ClinicAdmin" },
                    { "517ce587-6a78-45cb-8468-50d616b06a93", "23a4e039-afb8-42d6-808e-4fef4ff9f1b0", "Pacient", "Pacient" },
                    { "0774e700-5569-4399-bcac-1408a8f36b07", "18d81c1b-2a47-48a5-a136-de2410a9395d", "Doctor", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "SpecialitiesCatalog",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Prueba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03905782-71c8-4e18-81de-fda02e20636d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0774e700-5569-4399-bcac-1408a8f36b07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e48a9d-7de1-469d-b0a1-46c71a805a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "517ce587-6a78-45cb-8468-50d616b06a93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9d7a892-da98-4937-8500-77251882a5c7");

            migrationBuilder.DeleteData(
                table: "SpecialitiesCatalog",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cccd40b3-4b72-4e88-a2fd-4f68eeb4c1ad", "29340f91-031c-4cd8-9a37-7cd3dc2463ed", "SysAdmin", "SysAdmin" },
                    { "dd0f0e3b-34a9-436c-9ab3-a18cdf88df5c", "87043657-95aa-4321-9df4-eee230e829b5", "PacsAdmin", "PacsAdmin" },
                    { "b1bc64da-7c47-4267-8314-e1b9d738bcd4", "68e39c5f-2173-4a6f-bd0e-0de0322f41d8", "ClinicAdmin", "ClinicAdmin" },
                    { "3313023a-0ba4-4289-bc5b-391923bfd40c", "fd170dcc-8734-4c4d-8e6a-0f5d2e32d152", "Pacient", "Pacient" },
                    { "6ba980cd-9f27-4ce5-af83-4c4028a22efa", "9443bd57-accf-4a60-b2e4-fcd95a407c61", "Doctor", "Doctor" }
                });
        }
    }
}
