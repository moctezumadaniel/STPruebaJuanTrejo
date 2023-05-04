using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaSTJuanTrejo.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5ccbc77e-a9b5-4f69-ba28-03b22f90ee64"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("27bb1051-4a2f-4720-8e3c-f01f8828276c"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("c0fe330d-1911-4904-8f2b-b6fbc4189f3b"));

            migrationBuilder.CreateTable(
                name: "ItemToCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemToCustomers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "EmailAddress", "LastName", "Name", "Password" },
                values: new object[] { new Guid("eeacc4b7-30f9-4257-ac30-12bf1b160939"), "Dirección de prueba", "admin@gmail.com", "Administrador", "Administrador", "123456789" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "Image", "Price", "Stock", "StoreId" },
                values: new object[] { new Guid("262762eb-6251-4515-814d-26888ef9e4ca"), "ABC1234567", "Producto de prueba", "----", 1000.21, 100, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Branch" },
                values: new object[] { new Guid("431db6c8-47ba-4ca8-a6fb-e481325ab04d"), "Dirección de prueba", "Rama A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemToCustomers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("eeacc4b7-30f9-4257-ac30-12bf1b160939"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("262762eb-6251-4515-814d-26888ef9e4ca"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("431db6c8-47ba-4ca8-a6fb-e481325ab04d"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "EmailAddress", "LastName", "Name", "Password" },
                values: new object[] { new Guid("5ccbc77e-a9b5-4f69-ba28-03b22f90ee64"), "Dirección de prueba", "admin@gmail.com", "Administrador", "Administrador", "123456789" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Code", "Description", "Image", "Price", "Stock", "StoreId" },
                values: new object[] { new Guid("27bb1051-4a2f-4720-8e3c-f01f8828276c"), "ABC1234567", "Producto de prueba", "----", 1000.21, 100, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Branch" },
                values: new object[] { new Guid("c0fe330d-1911-4904-8f2b-b6fbc4189f3b"), "Dirección de prueba", "Rama A" });
        }
    }
}
