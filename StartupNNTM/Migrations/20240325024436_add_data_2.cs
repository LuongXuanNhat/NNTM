using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Province_AdministrativeRegionId",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Province_AdministrativeUnitId",
                table: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeRegionId",
                table: "Province",
                column: "AdministrativeRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeUnitId",
                table: "Province",
                column: "AdministrativeUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Province_AdministrativeRegionId",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Province_AdministrativeUnitId",
                table: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeRegionId",
                table: "Province",
                column: "AdministrativeRegionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeUnitId",
                table: "Province",
                column: "AdministrativeUnitId",
                unique: true);
        }
    }
}
