using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImageFiled3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtTokenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshJwtToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2326), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2342) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2351), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2357), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2358) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2361), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2365), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2370), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2371) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2374), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2379), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2380) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2383), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2388), new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2389) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2789), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2813), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2817), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2821), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2825), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2828), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2829) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2832), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2835), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2839), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2842), new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2843) });
        }
    }
}
