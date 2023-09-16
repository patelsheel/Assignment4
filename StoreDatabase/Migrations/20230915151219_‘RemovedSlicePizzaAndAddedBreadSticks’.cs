using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreDatabase.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSlicePizzaAndAddedBreadSticks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "ProductName",
                value: "Bread Sticks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "ProductName",
                value: "Slice Pizza");
        }
    }
}
