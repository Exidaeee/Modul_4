using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modul.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongsArtists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsArtists", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_SongsArtists_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongsArtists_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { -5, new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sadsvitmusic@gmail.com", "https://www.instagram.com/sadsvit/", "SadSvit", null },
                    { -4, new DateTime(1997, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/ado.khayat/", "Khayat", "380687618160" },
                    { -3, new DateTime(1993, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/dylanwishop/", "Dawid Podsiadlo", null },
                    { -2, new DateTime(2001, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Sobel", null },
                    { -1, new DateTime(1997, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/sanahmusic/", "Sanah", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { -5, "Indie" },
                    { -4, "Jahz" },
                    { -3, "Hip Hop" },
                    { -2, "Pop" },
                    { -1, "Rock" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { -5, new TimeSpan(0, 0, 2, 25, 0), -1, new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cassette" },
                    { -4, new TimeSpan(0, 0, 4, 0, 0), -2, new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra" },
                    { -3, new TimeSpan(0, 0, 3, 20, 0), -2, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "szampan" },
                    { -2, new TimeSpan(0, 0, 3, 9, 0), -5, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nic dwa razy" },
                    { -1, new TimeSpan(0, 0, 3, 14, 0), -2, new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mori" }
                });

            migrationBuilder.InsertData(
                table: "SongsArtists",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { -5, -5 },
                    { -4, -4 },
                    { -3, -1 },
                    { -1, -3 },
                    { -1, -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsArtists_SongId",
                table: "SongsArtists",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "SongsArtists");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
