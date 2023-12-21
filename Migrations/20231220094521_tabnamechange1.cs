using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    /// <inheritdoc />
    public partial class tabnamechange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "employeeNumber",
                table: "UserMedicalClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "UserMedicalClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalClaimViewModel",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmpanelled = table.Column<bool>(type: "bit", nullable: false),
                    claimAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalClaimViewModel", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalClaimViewModel");

            migrationBuilder.DropColumn(
                name: "employeeNumber",
                table: "UserMedicalClaim");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "UserMedicalClaim");
        }
    }
}
