using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingoWasm.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class BingoWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BingoWords",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    RegistUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RegistDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoWords", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BingoWords");
        }
    }
}
