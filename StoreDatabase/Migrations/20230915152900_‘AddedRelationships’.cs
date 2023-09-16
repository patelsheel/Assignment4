using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_OrderId",
                table: "OrderLineItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_ProductID",
                table: "OrderLineItem",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Orders_OrderId",
                table: "OrderLineItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Products_ProductID",
                table: "OrderLineItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Orders_OrderId",
                table: "OrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Products_ProductID",
                table: "OrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLineItem_OrderId",
                table: "OrderLineItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderLineItem_ProductID",
                table: "OrderLineItem");
        }
    }
}
