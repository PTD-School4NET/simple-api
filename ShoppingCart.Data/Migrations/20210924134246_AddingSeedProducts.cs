using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Data.Migrations
{
    public partial class AddingSeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "IsDeleted", "ModifiedAt", "Name", "Price" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 423, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 3, 0, 0, 0)), "product 1 description", "//todo", false, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 431, DateTimeKind.Unspecified).AddTicks(5017), new TimeSpan(0, 3, 0, 0, 0)), "Product 1", 100m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "IsDeleted", "ModifiedAt", "Name", "Price" },
                values: new object[] { 2L, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 431, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 3, 0, 0, 0)), "product 2 description", "//todo", false, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 431, DateTimeKind.Unspecified).AddTicks(9512), new TimeSpan(0, 3, 0, 0, 0)), "Product 2", 200m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "IsDeleted", "ModifiedAt", "Name", "Price" },
                values: new object[] { 3L, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 431, DateTimeKind.Unspecified).AddTicks(9605), new TimeSpan(0, 3, 0, 0, 0)), "product 3 description", "//todo", false, new DateTimeOffset(new DateTime(2021, 9, 24, 16, 42, 45, 431, DateTimeKind.Unspecified).AddTicks(9615), new TimeSpan(0, 3, 0, 0, 0)), "Product 3", 300m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
