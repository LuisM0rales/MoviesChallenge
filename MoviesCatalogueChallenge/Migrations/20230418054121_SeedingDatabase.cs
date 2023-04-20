using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesCatalogueChallenge.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Comedy" },
                    { 3, "Action" },
                    { 4, "Horror" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "admin", 1 },
                    { 2, "user@normal.com", "normal", 2 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CategoryId", "CreatedDate", "Name", "Poster", "ReleaseYear", "Synopsis", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 18, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6452), "Star Wars: A New Hope", new byte[0], 1977, "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", 1 },
                    { 2, 5, new DateTime(2023, 2, 16, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6465), "The Shawshank Redemption", new byte[0], 1994, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 1 },
                    { 3, 5, new DateTime(2023, 1, 17, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6466), "The Godfather", new byte[0], 1972, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }
    }
}
