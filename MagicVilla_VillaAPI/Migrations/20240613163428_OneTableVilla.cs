using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneTableVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Pool, Wi-Fi, BBQ", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8289), "Beautiful villa with sea view.", "https://example.com/villa1.jpg", "Villa Sunshine", 8, 350.0, 2500, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8301) },
                    { 2, "Fireplace, Hot Tub", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8307), "Cozy retreat in the mountains.", "https://example.com/villa2.jpg", "Mountain Retreat", 6, 200.0, 1500, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8307) },
                    { 3, "Gym, Wi-Fi", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8310), "Modern villa in the city center.", "https://example.com/villa3.jpg", "Urban Oasis", 4, 300.0, 1800, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8311) },
                    { 4, "Pool, Private Beach", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8313), "Luxury villa right on the beach.", "https://example.com/villa4.jpg", "Beachfront Paradise", 10, 500.0, 3000, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8314) },
                    { 5, "Garden, Wi-Fi", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8316), "Charming villa in the countryside.", "https://example.com/villa5.jpg", "Countryside Escape", 5, 250.0, 2200, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8317) },
                    { 6, "Pool, Outdoor Shower", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8319), "Quiet villa in the desert.", "https://example.com/villa6.jpg", "Desert Hideaway", 4, 280.0, 1600, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8320) },
                    { 7, "Canoe, Fireplace", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8322), "Relaxing villa by the lake.", "https://example.com/villa7.jpg", "Lakeside Cottage", 6, 220.0, 2000, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8322) },
                    { 8, "Pool, Hammocks", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8324), "Exotic villa in a tropical setting.", "https://example.com/villa8.jpg", "Tropical Getaway", 8, 400.0, 2700, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8325) },
                    { 9, "Ski Storage, Hot Tub", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8327), "Comfortable villa near the ski slopes.", "https://example.com/villa9.jpg", "Ski Chalet", 5, 310.0, 1400, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8327) },
                    { 10, "Hiking Trails, Wi-Fi", new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8329), "Peaceful villa in the forest.", "https://example.com/villa10.jpg", "Forest Retreat", 6, 270.0, 1900, new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8330) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "villas");
        }
    }
}
