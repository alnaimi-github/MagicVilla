using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneTableVilla2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1675), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1693), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1698), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1698) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1704), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1705) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1707), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1708) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1710), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1712), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1713) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1715), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1716) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1718), new DateTime(2024, 6, 14, 12, 36, 2, 835, DateTimeKind.Local).AddTicks(1719) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8289), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8307), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8310), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8313), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8316), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8319), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8322), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8324), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8327), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8329), new DateTime(2024, 6, 14, 5, 34, 25, 631, DateTimeKind.Local).AddTicks(8330) });
        }
    }
}
