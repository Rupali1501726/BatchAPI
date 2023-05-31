using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatchAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filedata = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatchDetails",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilesId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadUsers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyAttribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueAttribute = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchDetails", x => x.UId);
                    table.ForeignKey(
                        name: "FK_BatchDetails_files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchDetails_FilesId",
                table: "BatchDetails",
                column: "FilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchDetails");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
