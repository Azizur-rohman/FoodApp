using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEcommerceWebApp.Migrations
{
    public partial class AzModelsAddedByAziz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Hospitals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DoctorPersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    HospitalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorPersonalDetails_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorPersonalDetails_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorCertifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DoctorPersonalDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorCertifications_DoctorPersonalDetails_DoctorPersonalDetailId",
                        column: x => x.DoctorPersonalDetailId,
                        principalTable: "DoctorPersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorServiceCharges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ServiceCharge = table.Column<double>(nullable: false),
                    DoctorPersonalDetailId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorServiceCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorServiceCharges_DoctorPersonalDetails_DoctorPersonalDetailId",
                        column: x => x.DoctorPersonalDetailId,
                        principalTable: "DoctorPersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorServiceCharges_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DoctorPersonalDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialists_DoctorPersonalDetails_DoctorPersonalDetailId",
                        column: x => x.DoctorPersonalDetailId,
                        principalTable: "DoctorPersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorWorkingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    WorkingTimeStart = table.Column<DateTime>(nullable: false),
                    WorkingTimeEnd = table.Column<DateTime>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    DoctorPersonalDetailId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkingTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorWorkingTimes_DoctorPersonalDetails_DoctorPersonalDetailId",
                        column: x => x.DoctorPersonalDetailId,
                        principalTable: "DoctorPersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorWorkingTimes_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorCertifications_DoctorPersonalDetailId",
                table: "DoctorCertifications",
                column: "DoctorPersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPersonalDetails_DoctorId",
                table: "DoctorPersonalDetails",
                column: "DoctorId",
                unique: true,
                filter: "[DoctorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPersonalDetails_HospitalId",
                table: "DoctorPersonalDetails",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorServiceCharges_DoctorPersonalDetailId",
                table: "DoctorServiceCharges",
                column: "DoctorPersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorServiceCharges_HospitalId",
                table: "DoctorServiceCharges",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialists_DoctorPersonalDetailId",
                table: "DoctorSpecialists",
                column: "DoctorPersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkingTimes_DoctorPersonalDetailId",
                table: "DoctorWorkingTimes",
                column: "DoctorPersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkingTimes_HospitalId",
                table: "DoctorWorkingTimes",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorCertifications");

            migrationBuilder.DropTable(
                name: "DoctorServiceCharges");

            migrationBuilder.DropTable(
                name: "DoctorSpecialists");

            migrationBuilder.DropTable(
                name: "DoctorWorkingTimes");

            migrationBuilder.DropTable(
                name: "DoctorPersonalDetails");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Hospitals");
        }
    }
}
