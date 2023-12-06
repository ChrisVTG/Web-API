using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFakeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ludwig", "Lebrun" },
                    { 2, "Ludwig", "Leblanc" }
                });
            
            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PerformerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PerformerId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
            
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
        
        // Case 1 : generated code - update won't work since UpdateData is done BEFORE creation of entries in 'Users' table
        // In 'Down', same thing : DeleteData is done BEFORE PerformerId is set to null in table PcrTests
        // In this case, you can reorder Up/Down content by yourself
        /// <inheritdoc />
        // protected override void Up(MigrationBuilder migrationBuilder)
        // {
        //     migrationBuilder.UpdateData(
        //         table: "PcrTests",
        //         keyColumn: "Id",
        //         keyValue: 1,
        //         column: "PerformerId",
        //         value: 1);
        //
        //     migrationBuilder.UpdateData(
        //         table: "PcrTests",
        //         keyColumn: "Id",
        //         keyValue: 2,
        //         column: "PerformerId",
        //         value: 2);
        //
        //     migrationBuilder.InsertData(
        //         table: "Users",
        //         columns: new[] { "Id", "FirstName", "LastName" },
        //         values: new object[,]
        //         {
        //             { 1, "Ludwig", "Lebrun" },
        //             { 2, "Ludwig", "Leblanc" }
        //         });
        // }
        //
        // /// <inheritdoc />
        // protected override void Down(MigrationBuilder migrationBuilder)
        // {
        //     migrationBuilder.DeleteData(
        //         table: "Users",
        //         keyColumn: "Id",
        //         keyValue: 1);
        //
        //     migrationBuilder.DeleteData(
        //         table: "Users",
        //         keyColumn: "Id",
        //         keyValue: 2);
        //
        //     migrationBuilder.UpdateData(
        //         table: "PcrTests",
        //         keyColumn: "Id",
        //         keyValue: 1,
        //         column: "PerformerId",
        //         value: null);
        //
        //     migrationBuilder.UpdateData(
        //         table: "PcrTests",
        //         keyColumn: "Id",
        //         keyValue: 2,
        //         column: "PerformerId",
        //         value: null);
        // }
    }
}
