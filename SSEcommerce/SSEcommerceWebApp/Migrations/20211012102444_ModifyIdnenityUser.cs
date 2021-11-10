using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class ModifyIdnenityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "72b68a6c-24ab-47af-a3bc-8ac0f2eca4d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "d94b1ba0-596d-48f4-9b3b-ba7a6de63e99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "d02da2cb-785b-4b1a-9e4f-89520607a8d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "267d828d-3879-4bdd-b3ba-dd23ca594b97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "58c7af69-bbd9-4012-8938-ff6be21f7155", "AQAAAAEAACcQAAAAEDiezVQVXKqN6Yz7NnXevXxR/3PER/PYEJ0Vu8vuZcpI0Df8n8rJQQdxpEzoPrmecw==", "5d5078cb-94ee-4456-83b1-39dbe8a5e3c3", new DateTime(2021, 10, 11, 11, 29, 10, 802, DateTimeKind.Local).AddTicks(8154) });
        }
    }
}
