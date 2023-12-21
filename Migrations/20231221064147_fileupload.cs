using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    /// <inheritdoc />
    public partial class fileupload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalClaimViewModel");

            migrationBuilder.CreateTable(
                name: "UserMedicalClaimAttachment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    UserMedicalClaimid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedicalClaimAttachment", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserMedicalClaimAttachment_UserMedicalClaim_UserMedicalClaimid",
                        column: x => x.UserMedicalClaimid,
                        principalTable: "UserMedicalClaim",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMedicalClaimAttachment_UserMedicalClaimid",
                table: "UserMedicalClaimAttachment",
                column: "UserMedicalClaimid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMedicalClaimAttachment");

            migrationBuilder.CreateTable(
                name: "MedicalClaimViewModel",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimAmount = table.Column<int>(type: "int", nullable: false),
                    claimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmpanelled = table.Column<bool>(type: "bit", nullable: false),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalClaimViewModel", x => x.id);
                });
        }
    }
}
