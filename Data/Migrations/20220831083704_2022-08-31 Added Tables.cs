using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    public partial class _20220831AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostContentCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ContentIndex = table.Column<int>(type: "int", nullable: false),
                    PostContentType = table.Column<int>(type: "int", nullable: false),
                    CodeLanguage = table.Column<int>(type: "int", nullable: false),
                    ContentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentCode_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostContentImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ContentIndex = table.Column<int>(type: "int", nullable: false),
                    PostContentType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentImage_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostContentText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ContentIndex = table.Column<int>(type: "int", nullable: false),
                    PostContentType = table.Column<int>(type: "int", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentText_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostContentCode_PostId",
                table: "PostContentCode",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContentImage_PostId",
                table: "PostContentImage",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContentText_PostId",
                table: "PostContentText",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostContentCode");

            migrationBuilder.DropTable(
                name: "PostContentImage");

            migrationBuilder.DropTable(
                name: "PostContentText");
        }
    }
}
