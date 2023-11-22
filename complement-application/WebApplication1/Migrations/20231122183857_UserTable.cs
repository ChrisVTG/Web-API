using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Performer",
                table: "PcrTests");

            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "PcrTests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PcrTests_PerformerId",
                table: "PcrTests",
                column: "PerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PcrTests_Users_PerformerId",
                table: "PcrTests",
                column: "PerformerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcrTests_Users_PerformerId",
                table: "PcrTests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PcrTests_PerformerId",
                table: "PcrTests");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "PcrTests");

            migrationBuilder.AddColumn<string>(
                name: "Performer",
                table: "PcrTests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Performer",
                value: "Ludwig Lebrun");

            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Performer",
                value: "Ludwig Leblanc");
        }
    }
}
