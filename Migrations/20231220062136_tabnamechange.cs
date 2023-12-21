using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    /// <inheritdoc />
    public partial class tabnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalClaims_User_UserId",
                table: "medicalClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicalClaims",
                table: "medicalClaims");

            migrationBuilder.RenameTable(
                name: "medicalClaims",
                newName: "UserMedicalClaim");

            migrationBuilder.RenameIndex(
                name: "IX_medicalClaims_UserId",
                table: "UserMedicalClaim",
                newName: "IX_UserMedicalClaim_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMedicalClaim",
                table: "UserMedicalClaim",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicalClaim_User_UserId",
                table: "UserMedicalClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicalClaim_User_UserId",
                table: "UserMedicalClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMedicalClaim",
                table: "UserMedicalClaim");

            migrationBuilder.RenameTable(
                name: "UserMedicalClaim",
                newName: "medicalClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserMedicalClaim_UserId",
                table: "medicalClaims",
                newName: "IX_medicalClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicalClaims",
                table: "medicalClaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalClaims_User_UserId",
                table: "medicalClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
