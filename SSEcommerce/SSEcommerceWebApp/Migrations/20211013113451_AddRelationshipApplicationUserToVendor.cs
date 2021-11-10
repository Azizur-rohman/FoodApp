using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class AddRelationshipApplicationUserToVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorApplicationUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorParentId",
                table: "AspNetUsers",
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
                name: "IX_AspNetUsers_VendorApplicationUserId",
                table: "AspNetUsers",
                column: "VendorApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_VendorApplicationUserId",
                table: "AspNetUsers",
                column: "VendorApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_VendorApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VendorApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VendorApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VendorParentId",
                table: "AspNetUsers");

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
    }
}
