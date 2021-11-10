using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class newClassAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalWithDoctorsIds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(nullable: false),
                    DoctorPersonalDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalWithDoctorsIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalWithDoctorsIds_DoctorPersonalDetails_DoctorPersonalDetailId",
                        column: x => x.DoctorPersonalDetailId,
                        principalTable: "DoctorPersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalWithDoctorsIds_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWithDoctorsIds_DoctorPersonalDetailId",
                table: "HospitalWithDoctorsIds",
                column: "DoctorPersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalWithDoctorsIds_HospitalId",
                table: "HospitalWithDoctorsIds",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalWithDoctorsIds");
        }
    }
}
