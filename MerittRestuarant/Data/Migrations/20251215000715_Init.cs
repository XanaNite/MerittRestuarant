using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MerittRestuarant.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductIngredients",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    ProductIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Appetizers" },
                    { 2, null, "Main Courses" },
                    { 3, null, "Side Dish" },
                    { 4, null, "Beverages" },
                    { 5, null, "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Cayenne powder" },
                    { 2, null, "Salt" },
                    { 3, null, "Pine nuts" },
                    { 4, null, "Chicken" },
                    { 5, null, "Spinach" },
                    { 6, null, "Garlic" },
                    { 7, null, "Coconut aminos" },
                    { 8, null, "Olive oil" },
                    { 9, null, "Mushrooms" },
                    { 10, null, "Onion" },
                    { 11, null, "Coconut oil" },
                    { 12, null, "Nutritional yeast" },
                    { 13, null, "Chicken broth" },
                    { 14, null, "Coconut milk" },
                    { 15, null, "Polenta" },
                    { 16, null, "Broccoli" },
                    { 17, null, "Black cod" },
                    { 18, null, "Avocado oil" },
                    { 19, null, "Garlic powder" },
                    { 20, null, "Chicken seasoning" },
                    { 21, null, "Long grain brown rice" },
                    { 22, null, "Quinoa" },
                    { 23, null, "Sriracha mayo" },
                    { 24, null, "Brussel sprouts" },
                    { 25, null, "Salmon" },
                    { 26, null, "Cajun seasoning" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 2, "Air fried, tender chicken marinated in a spicy blend of cayenne powder and garlic.", "https://picsum.photos/id/292/200/300", "Air Fried Chicken", 12.99m, 50 },
                    { 2, 3, "Brussel sprouts roasted to perfection, topped with sriracha mayo for an extra kick.", "https://picsum.photos/id/292/200/300", "Roasted Brussel Sprouts", 9.99m, 50 },
                    { 3, 3, "A creammy polenta with mushrooms and spinach.", "https://picsum.photos/id/292/200/300", "Mushroom Spinach Polenta", 14.99m, 50 },
                    { 4, 2, "A buttery black cod marinated in a spicy blend of cayenne powder and garlic.", "https://picsum.photos/id/292/200/300", "Pan Fried Black Cod", 15.99m, 50 },
                    { 5, 2, "A spicy, pan fried salmon", "https://picsum.photos/id/292/200/300", "Cajun Salmon", 13.99m, 50 },
                    { 6, 3, "A garlicky rice quinoa mix.", "https://picsum.photos/id/292/200/300", "Garlic Rice", 7.99m, 50 },
                    { 7, 3, "A tender, roasted broccoli with sea salt.", "https://picsum.photos/id/292/200/300", "Roasted Broccoli", 8.99m, 50 }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredients",
                columns: new[] { "IngredientId", "ProductId", "ProductIngredientId" },
                values: new object[,]
                {
                    { 4, 1, 0 },
                    { 8, 1, 0 },
                    { 20, 1, 0 },
                    { 2, 2, 0 },
                    { 18, 2, 0 },
                    { 23, 2, 0 },
                    { 24, 2, 0 },
                    { 1, 3, 0 },
                    { 2, 3, 0 },
                    { 3, 3, 0 },
                    { 5, 3, 0 },
                    { 6, 3, 0 },
                    { 7, 3, 0 },
                    { 9, 3, 0 },
                    { 10, 3, 0 },
                    { 11, 3, 0 },
                    { 12, 3, 0 },
                    { 13, 3, 0 },
                    { 14, 3, 0 },
                    { 15, 3, 0 },
                    { 1, 4, 0 },
                    { 2, 4, 0 },
                    { 17, 4, 0 },
                    { 18, 4, 0 },
                    { 19, 4, 0 },
                    { 18, 5, 0 },
                    { 25, 5, 0 },
                    { 26, 5, 0 },
                    { 2, 6, 0 },
                    { 6, 6, 0 },
                    { 13, 6, 0 },
                    { 21, 6, 0 },
                    { 22, 6, 0 },
                    { 2, 7, 0 },
                    { 8, 7, 0 },
                    { 16, 7, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredients_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductIngredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
