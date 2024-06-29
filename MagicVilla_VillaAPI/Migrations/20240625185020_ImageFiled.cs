using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImageFiled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageLocalPath",
                table: "villas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2789), "https://example.com/villa1.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2813), "https://example.com/villa2.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2817), "https://example.com/villa3.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2821), "https://example.com/villa4.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2825), "https://example.com/villa5.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2828), "https://example.com/villa6.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2829) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2832), "https://example.com/villa7.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2835), "https://example.com/villa8.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2836) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2839), "https://example.com/villa9.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageLocalPath", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2842), "https://example.com/villa10.jpg", "", new DateTime(2024, 6, 26, 7, 50, 15, 109, DateTimeKind.Local).AddTicks(2843) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocalPath",
                table: "villas");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1105), "https://example.com/villa1.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1125) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1130), "https://example.com/villa2.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1132) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1136), "https://example.com/villa3.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1140), "https://example.com/villa4.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1144), "https://example.com/villa5.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1147), "https://example.com/villa6.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1148) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1151), "https://example.com/villa7.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1152) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1155), "https://example.com/villa8.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1156) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1158), "https://example.com/villa9.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1162), "https://example.com/villa10.jpg", new DateTime(2024, 6, 25, 9, 39, 13, 264, DateTimeKind.Local).AddTicks(1163) });
        }
    }
}
