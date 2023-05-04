using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaSTJuanTrejo.Migrations
{
    /// <inheritdoc />
    public partial class storeItemRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Items_Stores_StoreId",
            //    table: "Items",
            //    column: "StoreId",
            //    principalTable: "Stores",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}
