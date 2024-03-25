using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class add_data_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressVm");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AddressVm");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "AddressVm",
                newName: "Detail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Type",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "AddressVm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "AddressVm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "AddressVm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8a8c80fc-f6bb-4631-b682-14a7f33be54f"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2106), "Ngon-bổ-rẻ", null },
                    { new Guid("c63bab67-1b5a-4ac2-82a2-3333844543cf"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2091), "Chất lượng cao", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                table: "AddressVm",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProvinceId",
                table: "AddressVm",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_WardId",
                table: "AddressVm",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_DisTrict_DistrictId",
                table: "AddressVm",
                column: "DistrictId",
                principalTable: "DisTrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Province_ProvinceId",
                table: "AddressVm",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Ward_WardId",
                table: "AddressVm",
                column: "WardId",
                principalTable: "Ward",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_DisTrict_DistrictId",
                table: "AddressVm");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Province_ProvinceId",
                table: "AddressVm");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Ward_WardId",
                table: "AddressVm");

            migrationBuilder.DropIndex(
                name: "IX_Address_DistrictId",
                table: "AddressVm");

            migrationBuilder.DropIndex(
                name: "IX_Address_ProvinceId",
                table: "AddressVm");

            migrationBuilder.DropIndex(
                name: "IX_Address_WardId",
                table: "AddressVm");

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("8a8c80fc-f6bb-4631-b682-14a7f33be54f"));

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("c63bab67-1b5a-4ac2-82a2-3333844543cf"));

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "AddressVm");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "AddressVm");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "AddressVm");

            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "AddressVm",
                newName: "Ward");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}
