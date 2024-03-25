using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AddressVm",
                newName: "Ward");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressVm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AddressVm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdministrativeRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: false),
                    AdministrativeRegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_AdministrativeRegion_AdministrativeRegionId",
                        column: x => x.AdministrativeRegionId,
                        principalTable: "AdministrativeRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Province_AdministrativeUnit_AdministrativeUnitId",
                        column: x => x.AdministrativeUnitId,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisTrict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: false),
                    provinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisTrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisTrict_AdministrativeUnit_AdministrativeUnitId",
                        column: x => x.AdministrativeUnitId,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DisTrict_Province_provinceId",
                        column: x => x.provinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictCode = table.Column<int>(type: "int", nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: false),
                    districtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_AdministrativeUnit_AdministrativeUnitId",
                        column: x => x.AdministrativeUnitId,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ward_DisTrict_districtId",
                        column: x => x.districtId,
                        principalTable: "DisTrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AdministrativeRegion",
                columns: new[] { "Id", "CodeName", "CodeNameEn", "Name", "NameEn" },
                values: new object[,]
                {
                    { 1, "dong_bac_bo", "northeast", "Đông Bắc Bộ", "Northeast" },
                    { 2, "tay_bac_bo", "northwest", "Tây Bắc Bộ", "Northwest" },
                    { 3, "dong_bang_song_hong", "red_river_delta", "Đồng bằng sông Hồng", "Red River Delta" },
                    { 4, "bac_trung_bo", "north_central_coast", "Bắc Trung Bộ", "North Central Coast" },
                    { 5, "duyen_hai_nam_trung_bo", "south_central_coast", "Duyên hải Nam Trung Bộ", "South Central Coast" },
                    { 6, "tay_nguyen", "central_highlands", "Tây Nguyên", "Central Highlands" },
                    { 7, "dong_nam_bo", "southeast", "Đông Nam Bộ", "Southeast" },
                    { 8, "dong_bang_song_cuu_long", "southwest", "Đồng bằng sông Cửu Long", "Mekong River Delta" }
                });

            migrationBuilder.InsertData(
                table: "AdministrativeUnit",
                columns: new[] { "Id", "CodeName", "CodeNameEn", "FullName", "FullNameEn", "ShortName", "ShortNameEn" },
                values: new object[,]
                {
                    { 1, "thanh_pho_truc_thuoc_trung_uong", "municipality", "Thành phố trực thuộc trung ương", "Municipality", "Thành phố", "City" },
                    { 2, "tinh", "province", "Tỉnh", "Province", "Tỉnh", "Province" },
                    { 3, "thanh_pho_thuoc_thanh_pho_truc_thuoc_trung_uong", "municipal_city", "Thành phố thuộc thành phố trực thuộc trung ương", "Municipal city", "Thành phố", "City" },
                    { 4, "thanh_pho_thuoc_tinh", "provincial_city", "Thành phố thuộc tỉnh", "Provincial city", "Thành phố", "City" },
                    { 5, "quan", "urban_district", "Quận", "Urban district", "Quận", "District" },
                    { 6, "thi_xa", "district_level_town", "Thị xã", "District-level town", "Thị xã", "Town" },
                    { 7, "huyen", "district", "Huyện", "District", "Huyện", "District" },
                    { 8, "phuong", "ward", "Phường", "Ward", "Phường", "Ward" },
                    { 9, "thi_tran", "commune_level_town", "Thị trấn", "Commune-level town", "Thị trấn", "Township" },
                    { 10, "xa", "commune", "Xã", "Commune", "Xã", "Commune" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisTrict_AdministrativeUnitId",
                table: "DisTrict",
                column: "AdministrativeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DisTrict_provinceId",
                table: "DisTrict",
                column: "provinceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ward_AdministrativeUnitId",
                table: "Ward",
                column: "AdministrativeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_districtId",
                table: "Ward",
                column: "districtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "DisTrict");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "AdministrativeRegion");

            migrationBuilder.DropTable(
                name: "AdministrativeUnit");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressVm");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AddressVm");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "AddressVm",
                newName: "Name");
        }
    }
}
