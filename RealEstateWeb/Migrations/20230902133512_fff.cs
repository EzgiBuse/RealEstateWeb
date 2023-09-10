using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateWeb.Migrations
{
    /// <inheritdoc />
    public partial class fff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Msq = table.Column<double>(type: "float", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EstateNumbers",
                columns: table => new
                {
                    EstateNo = table.Column<int>(type: "int", nullable: false),
                    EstateID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateNumbers", x => x.EstateNo);
                    table.ForeignKey(
                        name: "FK_EstateNumbers_Estates_EstateID",
                        column: x => x.EstateID,
                        principalTable: "Estates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estates",
                columns: new[] { "ID", "DateCreated", "DateUpdated", "Details", "ImageURL", "Msq", "Name", "Occupancy", "Rate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "top floor home with a nice view", "images/home/slide1.jpg", 500.0, "Berlin Villa", 6, 200.0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top floor apartment with a balcony", "images/home/slide2.jpg", 100.0, "Munich Apartment", 2, 100.0 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family home with a garden", "images/villa/villa1.jpg", 100.0, "Munich Villa for Family", 1, 50.0 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Furnished house for small families", "images/villa/villa2.jpg", 400.0, "Canada House in Toronto", 5, 600.0 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Next to the shopping district", "images/villa/villa3.jpg", 600.0, "Düsseldorf Old Town House", 12, 1200.0 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newly decorated Villa in Essen", "images/villa/villa4.jpg", 600.0, "Essen Modern Villa", 3, 700.0 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minimalist Villa in Essen", "images/villa/villa5.jpg", 120.0, "Essen Tiny Villa", 2, 400.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateNumbers_EstateID",
                table: "EstateNumbers",
                column: "EstateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateNumbers");

            migrationBuilder.DropTable(
                name: "Estates");
        }
    }
}
