using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class changeduserrolesnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "416041e8-129a-4799-b0a9-6286451e8135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69974c13-9ce0-4c8b-a323-8e00168d6655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f775ba8-5049-43a2-adde-d209e6fe2d64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8729c7d-dcc8-49ff-a25d-d31b86ba8d22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c620b023-b367-4503-a909-3bb38fb2f66e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93294850-a6f8-450d-821a-72c562e647cf", "70b53263-c445-4a76-8295-f5e158b46629", "SysAdmin", "SysAdmin" },
                    { "94b46ad2-6153-417d-9351-aae963d6ab37", "946e17c0-7ee0-41ad-a071-47fcf4a72b72", "PacsAdmin", "PacsAdmin" },
                    { "d80f7754-3d5f-46fd-9bd4-0d98743cf64f", "a17f0967-2473-46b4-a4d0-709bc3c7828b", "ClinicAdmin", "ClinicAdmin" },
                    { "335ab758-fc61-4b8a-bbd8-ebbf36a31660", "14a66f6b-f7f1-4e42-8d9c-c311b8b7b413", "Pacient", "Pacient" },
                    { "c7908f5e-9a39-4910-a441-3b9a65e6b2f8", "f94dfbec-057f-42db-8f19-9fe4e7ac5e08", "Doctor", "Doctor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "335ab758-fc61-4b8a-bbd8-ebbf36a31660");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93294850-a6f8-450d-821a-72c562e647cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94b46ad2-6153-417d-9351-aae963d6ab37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7908f5e-9a39-4910-a441-3b9a65e6b2f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d80f7754-3d5f-46fd-9bd4-0d98743cf64f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8729c7d-dcc8-49ff-a25d-d31b86ba8d22", "597af680-fb0e-4734-9c62-06bf0b8811f2", "Sys Admin", "SysAdmin" },
                    { "c620b023-b367-4503-a909-3bb38fb2f66e", "ccdbcf2f-5757-4df1-b2fb-6da23fa405a0", "Pacs Admin", "PacsAdmin" },
                    { "416041e8-129a-4799-b0a9-6286451e8135", "0baf30c4-0438-47f8-be66-578c54cb2faa", "Clinic Admin", "ClinicAdmin" },
                    { "69974c13-9ce0-4c8b-a323-8e00168d6655", "b070da1b-59fd-4b73-b802-7d6c07045b86", "Pacient", "Pacient" },
                    { "9f775ba8-5049-43a2-adde-d209e6fe2d64", "7666effe-d298-4dc1-9bc1-ed828008a302", "Doctor", "Doctor" }
                });
        }
    }
}
