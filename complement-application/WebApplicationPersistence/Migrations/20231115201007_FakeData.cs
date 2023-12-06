using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FakeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PcrTests",
                columns: new[] { "Id", "AnalysisDate", "AnalysisResult", "Comment", "CreationDate", "Performer", "ReceptionDate", "SampleNumber", "SamplingDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Positive", "this is my comment 1", new DateTime(2023, 10, 30, 12, 54, 30, 0, DateTimeKind.Unspecified), "Ludwig Lebrun", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCD1234", new DateTime(2023, 10, 30, 12, 54, 30, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Negative", "this is my comment 2", new DateTime(2023, 11, 21, 9, 31, 24, 0, DateTimeKind.Unspecified), "Ludwig Leblanc", new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZREZ5241", new DateTime(2023, 11, 21, 9, 31, 24, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PcrTests",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
