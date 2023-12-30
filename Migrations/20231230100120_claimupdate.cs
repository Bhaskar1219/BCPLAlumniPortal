using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    /// <inheritdoc />
    public partial class claimupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "claimAmount",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "isEmpanelled",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "patientName",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "patientRelationship",
                table: "UserMedicalClaim");

            migrationBuilder.AddColumn<float>(
                name: "totalAmountApproved",
                table: "UserMedicalClaim",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "totalAmountClaimed",
                table: "UserMedicalClaim",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "MedicalClaimCharges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chargeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false),
                    particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    treatmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceRefNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placeOfTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isRecommended = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmpanelled = table.Column<bool>(type: "bit", nullable: false),
                    amountClaimed = table.Column<float>(type: "real", nullable: false),
                    amountApproved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMedicalClaimid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalClaimCharges", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicalClaimCharges_UserMedicalClaim_UserMedicalClaimid",
                        column: x => x.UserMedicalClaimid,
                        principalTable: "UserMedicalClaim",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalClaimCharges_UserMedicalClaimid",
                table: "MedicalClaimCharges",
                column: "UserMedicalClaimid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalClaimCharges");

            migrationBuilder.DropColumn(
                name: "totalAmountApproved",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "totalAmountClaimed",
                table: "UserMedicalClaim");

            migrationBuilder.AddColumn<int>(
                name: "claimAmount",
                table: "UserMedicalClaim",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "UserMedicalClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isEmpanelled",
                table: "UserMedicalClaim",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "patientName",
                table: "UserMedicalClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "patientRelationship",
                table: "UserMedicalClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
