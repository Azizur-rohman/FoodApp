using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class AddNewFieldInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasQuantity",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d4f58720-f463-4878-9bd8-38be17558c76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "bd8d0d3e-b342-459b-81bc-f07aaefb5750");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "531a943d-46c5-4c75-a659-2b1f3c832ad8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "9af3de2b-fe3b-47a5-bc32-cddc2d7b73f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "187b1d80-6a6d-48e4-bd69-2ad3182856b3", "AQAAAAEAACcQAAAAEJkdCXbH+cUY4QIRQEU0OLoPzZSBRmsGbHyEL1wgK5xnsI+WX/JCxK/BAQvSz0FOzQ==", "841d83e9-b745-4e31-ab71-5cc51f2345cc", new DateTime(2021, 10, 13, 11, 54, 55, 107, DateTimeKind.Local).AddTicks(630) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5d0e8d2c-7cc6-40e8-95f1-b31facc1005c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "44bf8522-cd77-49b0-bab0-cb8c75719aa0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "c3088876-cd15-45f4-ae33-7ca5e295e34c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "59693d81-f942-4e12-90ca-a7768206d4bc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "f831c205-56ce-4d62-a73a-ac28f4cc7ef9", "AQAAAAEAACcQAAAAEGc6iBkSrWZzpJgvQzfeTP7CX7FoiHfXX2F86/VcLO709Wfk7GZc7dwcpqoIatO5pQ==", "2c92c301-90f0-449f-95aa-2f1aea02a346", new DateTime(2021, 10, 13, 0, 20, 46, 105, DateTimeKind.Local).AddTicks(9887) });
        }
    }
}
