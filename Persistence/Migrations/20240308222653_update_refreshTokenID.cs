using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_refreshTokenID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "App",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "App",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                schema: "App",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "App",
                table: "RefreshTokens",
                column: "Token");

            migrationBuilder.UpdateData(
                schema: "App",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f613a853-894e-4870-a901-932b8da87561", "AQAAAAIAAYagAAAAEJjsA1B2DRw2D473TxS0OKbmDIJPqfj83HzmFhWnVEyRLULbuZMbOR73qm2ssDxWTQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "App",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                schema: "App",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "App",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "App",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "App",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50b5ed70-7653-4e2c-8c6d-eed2aa944e26", "AQAAAAIAAYagAAAAEIqW5tgN1ee8DGcLmqA/XBEIHPOj4V3E7tgN5vufSA98/XpKyA3jt3ccyp5eEmnQ2g==" });
        }
    }
}
