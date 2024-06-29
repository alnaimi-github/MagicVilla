using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneTableVilla4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4648), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4667), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4672), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4675), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4679), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4682), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4686), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4690), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4694), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4697), new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4698) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

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
        }
    }
}
