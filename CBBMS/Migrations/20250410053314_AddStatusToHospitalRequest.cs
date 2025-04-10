using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBBMS.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToHospitalRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "HospitalRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HospitalRequests");
        }
    }
}
