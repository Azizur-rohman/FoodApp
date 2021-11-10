using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class UpdateSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "71e1798b-dae8-4075-96cc-f2d2318acd5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "37df6248-629f-4221-8dcf-796cac349ce4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "d0342631-e6ee-43a8-8d78-394885576e5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "cb2cbc09-3ce6-447a-b93d-cecbe726b3df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "4d4597bf-f794-4de6-b8bb-460fd63246b2", "AQAAAAEAACcQAAAAEHAPd7QK3gYnY+mGKTYeYoTrVtJUYKtB1EaKSkbk6NGUQglPA2T6LlpxdrAOM11CIw==", "205eb012-e84e-43e1-a0eb-a8c1074dc5fa", new DateTime(2021, 10, 14, 12, 20, 38, 247, DateTimeKind.Local).AddTicks(3028) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b457ead5-2a07-4c0c-b561-bfbe59897177");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "e9ad099b-a3b7-4a10-8524-f40858b09695");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "f7832905-fb2a-4cc3-ac70-31d73e9c0a62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "bb09df88-13bb-4ded-b529-3a6477039b7c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "8745fdda-3f14-4dce-be20-38d393674956", "AQAAAAEAACcQAAAAEA/COBf3cXYE499mOnbCRoXlCc70tQXfxWrgCJHyPrUwy1pRt8SeOPZw/WbUdhpT2A==", "d1c16286-6945-4eca-bb38-1aaf6442c5a3", new DateTime(2021, 10, 14, 11, 2, 54, 540, DateTimeKind.Local).AddTicks(2751) });
        }
    }
}
