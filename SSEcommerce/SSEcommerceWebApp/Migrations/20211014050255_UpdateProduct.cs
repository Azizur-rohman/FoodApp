using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryId1",
                table: "Products");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f458eb5d-aca5-4f68-b981-15a7dd44e654");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "84c336e2-510e-4bd5-8e0b-5b6220adf544");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "4b6e2d22-7012-4877-84b9-76b23f3c0010");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "816808ba-5b09-4044-aaec-14860b935adb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "CreatedDate" },
                values: new object[] { "9fd2e66f-439a-409b-bea6-83b4ecfcf5ea", "AQAAAAEAACcQAAAAEFsJ4dBYB64r6rZEr651C75hxFhNbLJk4+c+nQvIqxJj9RH2g1dGzwtOSLAsfsbmLA==", "16b6e695-7551-4482-ade3-31178b45615d", new DateTime(2021, 10, 13, 17, 34, 50, 930, DateTimeKind.Local).AddTicks(4144) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId1",
                table: "Products",
                column: "SubCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId1",
                table: "Products",
                column: "SubCategoryId1",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
