using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DisTrict");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Ward",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DisTrict",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
