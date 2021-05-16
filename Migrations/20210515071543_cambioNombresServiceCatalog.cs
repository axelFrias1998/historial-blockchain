using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class cambioNombresServiceCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "cccd40b3-4b72-4e88-a2fd-4f68eeb4c1ad", "29340f91-031c-4cd8-9a37-7cd3dc2463ed", "SysAdmin", "SysAdmin" },
                    { "dd0f0e3b-34a9-436c-9ab3-a18cdf88df5c", "87043657-95aa-4321-9df4-eee230e829b5", "PacsAdmin", "PacsAdmin" },
                    { "b1bc64da-7c47-4267-8314-e1b9d738bcd4", "68e39c5f-2173-4a6f-bd0e-0de0322f41d8", "ClinicAdmin", "ClinicAdmin" },
                    { "3313023a-0ba4-4289-bc5b-391923bfd40c", "fd170dcc-8734-4c4d-8e6a-0f5d2e32d152", "Pacient", "Pacient" },
                    { "6ba980cd-9f27-4ce5-af83-4c4028a22efa", "9443bd57-accf-4a60-b2e4-fcd95a407c61", "Doctor", "Doctor" }
                });

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Hospital público");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Hospital privado");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Clínica pública");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Clínica privada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "aa4e3329-742f-48fa-b651-da3fcbab3dfd", "79393d4f-346f-4ab2-84c2-975e82caa466", "SysAdmin", "SysAdmin" },
                    { "b2c7a13c-ceed-487e-9c23-12c5af98b250", "d56b66a9-b464-4f99-8a40-e43d0ba3094f", "PacsAdmin", "PacsAdmin" },
                    { "65f8f8de-c554-419f-a1cf-8a5170c31736", "94746652-aaa5-4629-8737-8ec629c13cee", "ClinicAdmin", "ClinicAdmin" },
                    { "f1265d40-9487-4dcc-bbbd-f73aff712c1b", "e9664b85-eb11-442e-b762-c356d693e7c8", "Pacient", "Pacient" },
                    { "cbbadc36-9c49-4dae-9382-5f9a698e0c15", "39da105b-7c3f-46c6-9777-699e5e19275c", "Doctor", "Doctor" }
                });

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Hospital");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Hospital");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Clínica");

            migrationBuilder.UpdateData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Clínica");
        }
    }
}
