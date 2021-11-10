using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class SomeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorPersonalDetailId",
                table: "Hospitals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_DoctorPersonalDetailId",
                table: "Hospitals",
                column: "DoctorPersonalDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_DoctorPersonalDetails_DoctorPersonalDetailId",
                table: "Hospitals",
                column: "DoctorPersonalDetailId",
                principalTable: "DoctorPersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_DoctorPersonalDetails_DoctorPersonalDetailId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_DoctorPersonalDetailId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DoctorPersonalDetailId",
                table: "Hospitals");
        }
    }
}
