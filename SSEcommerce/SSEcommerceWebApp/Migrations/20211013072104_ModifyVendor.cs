using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class ModifyVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5058453c-c505-4cdf-b7af-d334ca88be49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "7fbbaf49-ed02-4a8f-ba60-2e295947b4dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "9e849976-d471-4fb4-9b52-10b9ab57aebe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "c982bf07-b616-433e-a054-49a300bdbc35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "1ea99462-ce13-4b37-8ae8-a5f1d8ffd258", "AQAAAAEAACcQAAAAEGhYDA0xhv3G8De7FS4rXdCw69wjZLv74zQSGiVSRgFJN8Ey6LwqMpR2ePIelHJ2mw==", "21d72cbf-d6b9-43e1-b67a-b43705074591", new DateTime(2021, 10, 13, 13, 21, 3, 85, DateTimeKind.Local).AddTicks(5384) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "AspNetUsers");

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
    }
}
