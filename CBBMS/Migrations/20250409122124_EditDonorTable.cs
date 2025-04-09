using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBBMS.Migrations
{
    /// <inheritdoc />
    public partial class EditDonorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationRequests_Donors_DonorId",
                table: "DonationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_AspNetUsers_ApplicationUserId",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_ApplicationUserId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Donors");

            migrationBuilder.AddColumn<string>(
                name: "DonorId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DonorId",
                table: "DonationRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationRequests_Donors_DonorId",
                table: "DonationRequests",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_AspNetUsers_DonorId",
                table: "Donors",
                column: "DonorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationRequests_Donors_DonorId",
                table: "DonationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_AspNetUsers_DonorId",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Donors");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonorId",
                table: "DonationRequests",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "NationalID");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_ApplicationUserId",
                table: "Donors",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationRequests_Donors_DonorId",
                table: "DonationRequests",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "NationalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_AspNetUsers_ApplicationUserId",
                table: "Donors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
