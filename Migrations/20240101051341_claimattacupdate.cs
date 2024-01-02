using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCPLAlumniPortal.Migrations
{
    /// <inheritdoc />
    public partial class claimattacupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicalClaimAttachment_UserMedicalClaim_UserMedicalClaimid",
                table: "UserMedicalClaimAttachment");

            migrationBuilder.RenameColumn(
                name: "UserMedicalClaimid",
                table: "UserMedicalClaimAttachment",
                newName: "MedicalClaimChargesid");

            migrationBuilder.RenameIndex(
                name: "IX_UserMedicalClaimAttachment_UserMedicalClaimid",
                table: "UserMedicalClaimAttachment",
                newName: "IX_UserMedicalClaimAttachment_MedicalClaimChargesid");

            migrationBuilder.AddColumn<bool>(
                name: "isSubmitted",
                table: "UserMedicalClaim",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicalClaimAttachment_MedicalClaimCharges_MedicalClaimChargesid",
                table: "UserMedicalClaimAttachment",
                column: "MedicalClaimChargesid",
                principalTable: "MedicalClaimCharges",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicalClaimAttachment_MedicalClaimCharges_MedicalClaimChargesid",
                table: "UserMedicalClaimAttachment");

            migrationBuilder.DropColumn(
                name: "isSubmitted",
                table: "UserMedicalClaim");

            migrationBuilder.RenameColumn(
                name: "MedicalClaimChargesid",
                table: "UserMedicalClaimAttachment",
                newName: "UserMedicalClaimid");

            migrationBuilder.RenameIndex(
                name: "IX_UserMedicalClaimAttachment_MedicalClaimChargesid",
                table: "UserMedicalClaimAttachment",
                newName: "IX_UserMedicalClaimAttachment_UserMedicalClaimid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicalClaimAttachment_UserMedicalClaim_UserMedicalClaimid",
                table: "UserMedicalClaimAttachment",
                column: "UserMedicalClaimid",
                principalTable: "UserMedicalClaim",
                principalColumn: "id");
        }
    }
}
