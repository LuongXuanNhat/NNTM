using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartupNNTM.Migrations
{
    /// <inheritdoc />
    public partial class createtablefeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicFeedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFeedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_TopicFeedback_TopicFeedbackId",
                        column: x => x.TopicFeedbackId,
                        principalTable: "TopicFeedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_TypeFeedback_TypeFeedbackId",
                        column: x => x.TypeFeedbackId,
                        principalTable: "TypeFeedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "TopicFeedback",
                columns: new[] { "Id", "CreatedAt", "Content", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("37E41DD1-E264-4C8A-AD33-D4CBBF90A1B2"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2106), "Phản hồi - Khiếu nại", null },
                    { new Guid("D1CADCB1-15C2-4D7D-9C32-299065E8E277"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2091), "Góp ý", null }

                });


            migrationBuilder.InsertData(
               table: "TypeFeedback",
               columns: new[] { "Id", "CreatedAt", "Content", "UpdatedAt" },
               values: new object[,]
               {

                    { new Guid("37DAAD21-9F10-4AC8-955D-69C85E4F2A4E"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2106), "Sản phẩm", null },
                    { new Guid("290CA114-4F7E-46F9-AE8B-DB63B57A52BF"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2091), "Giá cả", null },
                    { new Guid("94D53B67-C36D-430E-A360-7B25CFEF7E2D"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2106), "Dịch vụ", null },
                    { new Guid("8933C2A8-9287-410F-AE46-EF1BB1405D9D"), new DateTime(2024, 3, 25, 11, 17, 11, 19, DateTimeKind.Local).AddTicks(2091), "Khác", null }
               });


      

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TopicFeedbackId",
                table: "Feedback",
                column: "TopicFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TypeFeedbackId",
                table: "Feedback",
                column: "TypeFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "TopicFeedback");

            migrationBuilder.DropTable(
                name: "TypeFeedback");

        }
    }
}
