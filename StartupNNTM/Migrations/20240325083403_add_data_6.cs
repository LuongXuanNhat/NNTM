using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_DisTrict_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DisTrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Addresses_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Addresses_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("8a8c80fc-f6bb-4631-b682-14a7f33be54f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 15, 34, 3, 187, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("c63bab67-1b5a-4ac2-82a2-3333844543cf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 15, 34, 3, 187, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Address",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_WardId",
                table: "Address",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Addresses_AddressId",
                table: "Post",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Addresses_AddressId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.CreateTable(
                name: "AddressVm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressVm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressVm_DisTrict_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DisTrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AddressVm_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AddressVm_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("8a8c80fc-f6bb-4631-b682-14a7f33be54f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("c63bab67-1b5a-4ac2-82a2-3333844543cf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.CreateIndex(
                name: "IX_AddressVm_DistrictId",
                table: "AddressVm",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressVm_ProvinceId",
                table: "AddressVm",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressVm_WardId",
                table: "AddressVm",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AddressVm_AddressId",
                table: "Post",
                column: "AddressId",
                principalTable: "AddressVm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
