using Microsoft.EntityFrameworkCore.Migrations;

namespace Practices.API.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_practice_t_Product_ProductId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartId",
                table: "LineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "practice_t_ShoppingCart");

            migrationBuilder.RenameTable(
                name: "LineItems",
                newName: "practice_t_LineItem");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ShoppingCartId",
                table: "practice_t_LineItem",
                newName: "IX_practice_t_LineItem_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
                table: "practice_t_LineItem",
                newName: "IX_practice_t_LineItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_practice_t_ShoppingCart",
                table: "practice_t_ShoppingCart",
                column: "ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_practice_t_LineItem",
                table: "practice_t_LineItem",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_practice_t_LineItem_practice_t_Product_ProductId",
                table: "practice_t_LineItem",
                column: "ProductId",
                principalTable: "practice_t_Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_practice_t_LineItem_practice_t_ShoppingCart_ShoppingCartId",
                table: "practice_t_LineItem",
                column: "ShoppingCartId",
                principalTable: "practice_t_ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_practice_t_LineItem_practice_t_Product_ProductId",
                table: "practice_t_LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_practice_t_LineItem_practice_t_ShoppingCart_ShoppingCartId",
                table: "practice_t_LineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_practice_t_ShoppingCart",
                table: "practice_t_ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_practice_t_LineItem",
                table: "practice_t_LineItem");

            migrationBuilder.RenameTable(
                name: "practice_t_ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "practice_t_LineItem",
                newName: "LineItems");

            migrationBuilder.RenameIndex(
                name: "IX_practice_t_LineItem_ShoppingCartId",
                table: "LineItems",
                newName: "IX_LineItems_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_practice_t_LineItem_ProductId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "ShoppingCartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_practice_t_Product_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "practice_t_Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartId",
                table: "LineItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
