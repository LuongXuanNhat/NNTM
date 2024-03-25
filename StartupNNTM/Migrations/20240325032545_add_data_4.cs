using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisTrict_Province_provinceId",
                table: "DisTrict");

            migrationBuilder.DropForeignKey(
                name: "FK_Ward_DisTrict_districtId",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "DisTrict");

            migrationBuilder.RenameColumn(
                name: "districtId",
                table: "Ward",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Ward_districtId",
                table: "Ward",
                newName: "IX_Ward_DistrictId");

            migrationBuilder.RenameColumn(
                name: "provinceId",
                table: "DisTrict",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_DisTrict_provinceId",
                table: "DisTrict",
                newName: "IX_DisTrict_ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisTrict_Province_ProvinceId",
                table: "DisTrict",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ward_DisTrict_DistrictId",
                table: "Ward",
                column: "DistrictId",
                principalTable: "DisTrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisTrict_Province_ProvinceId",
                table: "DisTrict");

            migrationBuilder.DropForeignKey(
                name: "FK_Ward_DisTrict_DistrictId",
                table: "Ward");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "Ward",
                newName: "districtId");

            migrationBuilder.RenameIndex(
                name: "IX_Ward_DistrictId",
                table: "Ward",
                newName: "IX_Ward_districtId");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "DisTrict",
                newName: "provinceId");

            migrationBuilder.RenameIndex(
                name: "IX_DisTrict_ProvinceId",
                table: "DisTrict",
                newName: "IX_DisTrict_provinceId");

            migrationBuilder.AddColumn<int>(
                name: "DistrictCode",
                table: "Ward",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "DisTrict",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DisTrict_Province_provinceId",
                table: "DisTrict",
                column: "provinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ward_DisTrict_districtId",
                table: "Ward",
                column: "districtId",
                principalTable: "DisTrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
