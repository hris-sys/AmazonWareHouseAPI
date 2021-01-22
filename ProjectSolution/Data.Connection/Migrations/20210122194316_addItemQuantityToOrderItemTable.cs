using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Connection.Migrations
{
    public partial class addItemQuantityToOrderItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemQuantity",
                table: "OrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "OrdersItems");
        }
    }
}
