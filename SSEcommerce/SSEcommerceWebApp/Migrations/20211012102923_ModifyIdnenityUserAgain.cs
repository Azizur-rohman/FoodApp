using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class ModifyIdnenityUserAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3fc49ac8-c4c6-4393-bf0d-234a37fc3169");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "59771fd1-f915-48e4-81f6-3e7c61d99404");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "16f30f57-407c-430b-9954-a9a4749e8e37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "0faa1ed4-d59a-4243-9df2-9988294aa62c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "89f49d31-8158-45d1-8e3a-7e5ee5934df3", "AQAAAAEAACcQAAAAEJUVZqLC+keitnpJMkMW70rWkTmMImoP6Wap9YifMJ5NoE8QD3mxP1v1LjdqWizCww==", "2fea2ab7-f563-458c-9b0d-a4edada998b1", new DateTime(2021, 10, 12, 16, 29, 23, 57, DateTimeKind.Local).AddTicks(7822) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4e82d62a-4152-4347-9f42-a01444845812");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "87dd57b4-59c3-432c-9934-bb1e7e9d6e5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "00f20bd4-4adf-4c69-84c5-90952d80c3a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "fcfb2d38-0281-4f3a-8150-400eee031185");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "50a02ca1-9aa4-44d8-a841-532b9b07a45d", "AQAAAAEAACcQAAAAEP0Kqgm/+DEiHJ9ievuOBTPVElwq/xKY7wv2/DP01qjqlZaJxhz2OnJSXWqQixbkRQ==", "ba665bbe-c095-4e59-ae00-743db39d50c9", new DateTime(2021, 10, 12, 16, 24, 43, 738, DateTimeKind.Local).AddTicks(6252) });
        }
    }
}
