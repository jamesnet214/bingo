using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingoWasm.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class BingoWord2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BingoWords",
                table: "BingoWords");

            migrationBuilder.AlterColumn<string>(
                name: "RegistUser",
                table: "BingoWords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BingoWords",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BingoWords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BingoWords",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BingoWords",
                table: "BingoWords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BingoWords_Name",
                table: "BingoWords",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BingoWords",
                table: "BingoWords");

            migrationBuilder.DropIndex(
                name: "IX_BingoWords_Name",
                table: "BingoWords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BingoWords");

            migrationBuilder.AlterColumn<string>(
                name: "RegistUser",
                table: "BingoWords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BingoWords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BingoWords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BingoWords",
                table: "BingoWords",
                column: "Name");
        }
    }
}
