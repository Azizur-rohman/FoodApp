using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class AddUserPointToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Divisions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Districts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserPoints",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Areas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPoints",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Divisions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Districts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Areas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "71e1798b-dae8-4075-96cc-f2d2318acd5d", "Administrator", "ADMINISTRATOR" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "37df6248-629f-4221-8dcf-796cac349ce4", "Vendor", "VENDOR" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "d0342631-e6ee-43a8-8d78-394885576e5e", "Customer", "CUSTOMER" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7213", "cb2cbc09-3ce6-447a-b93d-cecbe726b3df", "Delivery Men", "DELIVERY MEN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "ContactPersonName", "CreatedBy", "CreatedDate", "FacebookPageLink", "FirstName", "IsActive", "IsApproved", "IsAvailable", "LastName", "LogoPath", "MenuImagePath", "NidImagePath", "RestaurantImagePath", "RestaurantName", "RestaurantTypeId", "UpdatedBy", "UpdatedDate", "UserImagePath", "VendorApplicationUserId", "VendorParentId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "4d4597bf-f794-4de6-b8bb-460fd63246b2", "ApplicationUser", "hmuzzal@mail.com", true, false, null, "HMUZZAL@MAIL.COM", "01715637290", "AQAAAAEAACcQAAAAEHAPd7QK3gYnY+mGKTYeYoTrVtJUYKtB1EaKSkbk6NGUQglPA2T6LlpxdrAOM11CIw==", "01715637290", true, "205eb012-e84e-43e1-a0eb-a8c1074dc5fa", false, "01715637290", null, null, null, new DateTime(2021, 10, 14, 12, 20, 38, 247, DateTimeKind.Local).AddTicks(3028), null, "Hasan", true, false, false, "Mahmud", null, null, null, null, null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });
        }
    }
}
