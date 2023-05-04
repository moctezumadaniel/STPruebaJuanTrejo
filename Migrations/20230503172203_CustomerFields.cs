using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaSTJuanTrejo.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b7b0605d-9f30-4a76-9b36-ad5745e1f415"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1d8f1d85-b504-4c03-b3e8-eb3bf895a704"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("2a10cf21-0f98-46da-bb66-e452e56faef6"));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "EmailAddress", "LastName", "Name", "Password" },
                values: new object[] { new Guid("ad31c6bb-4f37-415f-9a96-36721e7d2750"), "Dirección de prueba", "admin@gmail.com", "Administrador", "Administrador", "123456789" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "Image", "Price", "Stock", "StoreId" },
                values: new object[] { new Guid("3039bac4-4520-49b0-ba88-7d94f80c5faf"), "ABC1234567", "Producto de prueba", "----", 1000.21, 100, null });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Branch" },
                values: new object[] { new Guid("991433ff-f7d0-46ee-af9a-be6c379c733f"), "Dirección de prueba", "Rama A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ad31c6bb-4f37-415f-9a96-36721e7d2750"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3039bac4-4520-49b0-ba88-7d94f80c5faf"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("991433ff-f7d0-46ee-af9a-be6c379c733f"));

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "LastName", "Name" },
                values: new object[] { new Guid("b7b0605d-9f30-4a76-9b36-ad5745e1f415"), "Dirección de prueba", "Administrador", "Administrador" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "Image", "Price", "Stock", "StoreId" },
                values: new object[] { new Guid("1d8f1d85-b504-4c03-b3e8-eb3bf895a704"), "ABC1234567", "Producto de prueba", "----", 1000.21, 100, null });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Branch" },
                values: new object[] { new Guid("2a10cf21-0f98-46da-bb66-e452e56faef6"), "Dirección de prueba", "Rama A" });
        }
    }
}
