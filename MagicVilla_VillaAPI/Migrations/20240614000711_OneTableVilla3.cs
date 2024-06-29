using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneTableVilla3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4019), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4043), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4048), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4052), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4056), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4064), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4067), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4071), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 6, 14, 13, 7, 10, 668, DateTimeKind.Local).AddTicks(4076) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_villas_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_villas_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumbers");

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
    }
}
