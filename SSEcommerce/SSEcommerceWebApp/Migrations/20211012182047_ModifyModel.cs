using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class ModifyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8addc006-f635-4f87-9b8d-108d0f566548");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "db690587-3563-4c96-96d0-4585aac0ce6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "ed04fcec-39f4-4b09-89c0-49e292c8801a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "2f029b33-771d-424a-8fd2-e104eb05a70e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "2d267ba1-0844-40ed-a51a-3073fc4d5a2b", "AQAAAAEAACcQAAAAEE9I4I1bNyyY8+rMWeSB5WAVEY8DPu6STUVKFO5ul9NVwdltYpa6xERUko8BqqaFYA==", "78b773ce-7f14-450a-8ecb-3407047e51c6", new DateTime(2021, 10, 12, 17, 16, 52, 963, DateTimeKind.Local).AddTicks(22) });
        }
    }
}
