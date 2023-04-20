using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalogueChallenge.Migrations
{
    /// <inheritdoc />
    public partial class RatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 19, 23, 31, 31, 381, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 17, 23, 31, 31, 381, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 18, 23, 31, 31, 381, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 18, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 16, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 17, 23, 41, 21, 48, DateTimeKind.Local).AddTicks(6466));
        }
    }
}
