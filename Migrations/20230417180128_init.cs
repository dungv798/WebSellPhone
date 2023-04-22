using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForSell.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Dofweek",
                columns: table => new
                {
                    DofweekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDoTW = table.Column<bool>(type: "bit", nullable: false),
                    DofweekName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DofweekPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DofweekDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DofweekImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dofweek", x => x.DofweekId);
                });

            migrationBuilder.CreateTable(
                name: "LastestProduct",
                columns: table => new
                {
                    LastestProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isLasted = table.Column<bool>(type: "bit", nullable: false),
                    LastestProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastestProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    LastestProductImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastestProduct", x => x.LastestProductId);
                });

            migrationBuilder.CreateTable(
                name: "NewArr",
                columns: table => new
                {
                    NewArrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isArr = table.Column<bool>(type: "bit", nullable: false),
                    NewArrName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NewArrPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NewArrImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewArr", x => x.NewArrId);
                });

            migrationBuilder.CreateTable(
                name: "OnSale",
                columns: table => new
                {
                    OnSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isOnSale = table.Column<bool>(type: "bit", nullable: false),
                    OnSaleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnSalePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OnSaleImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnSale", x => x.OnSaleId);
                });

            migrationBuilder.CreateTable(
                name: "TopSell",
                columns: table => new
                {
                    TopSellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isTop = table.Column<bool>(type: "bit", nullable: false),
                    TopSellName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopSellPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    TopSellImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopSell", x => x.TopSellId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "HomeProduct",
                columns: table => new
                {
                    HomeProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NewArrId = table.Column<int>(type: "int", nullable: false),
                    TopSellId = table.Column<int>(type: "int", nullable: false),
                    OnSaleId = table.Column<int>(type: "int", nullable: false),
                    LastestProductId = table.Column<int>(type: "int", nullable: false),
                    DofweekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProduct", x => x.HomeProductId);
                    table.ForeignKey(
                        name: "FK_HomeProduct_Dofweek_DofweekId",
                        column: x => x.DofweekId,
                        principalTable: "Dofweek",
                        principalColumn: "DofweekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProduct_LastestProduct_LastestProductId",
                        column: x => x.LastestProductId,
                        principalTable: "LastestProduct",
                        principalColumn: "LastestProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProduct_NewArr_NewArrId",
                        column: x => x.NewArrId,
                        principalTable: "NewArr",
                        principalColumn: "NewArrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProduct_OnSale_OnSaleId",
                        column: x => x.OnSaleId,
                        principalTable: "OnSale",
                        principalColumn: "OnSaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeProduct_TopSell_TopSellId",
                        column: x => x.TopSellId,
                        principalTable: "TopSell",
                        principalColumn: "TopSellId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    isDoTW = table.Column<bool>(type: "bit", nullable: false),
                    DofweekId = table.Column<int>(type: "int", nullable: true),
                    isLasted = table.Column<bool>(type: "bit", nullable: false),
                    LastestProductId = table.Column<int>(type: "int", nullable: true),
                    isArr = table.Column<bool>(type: "bit", nullable: false),
                    NewArrId = table.Column<int>(type: "int", nullable: true),
                    isOnSale = table.Column<bool>(type: "bit", nullable: false),
                    OnSaleId = table.Column<int>(type: "int", nullable: true),
                    isTop = table.Column<bool>(type: "bit", nullable: false),
                    TopSellId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Dofweek_DofweekId",
                        column: x => x.DofweekId,
                        principalTable: "Dofweek",
                        principalColumn: "DofweekId");
                    table.ForeignKey(
                        name: "FK_Product_LastestProduct_LastestProductId",
                        column: x => x.LastestProductId,
                        principalTable: "LastestProduct",
                        principalColumn: "LastestProductId");
                    table.ForeignKey(
                        name: "FK_Product_NewArr_NewArrId",
                        column: x => x.NewArrId,
                        principalTable: "NewArr",
                        principalColumn: "NewArrId");
                    table.ForeignKey(
                        name: "FK_Product_OnSale_OnSaleId",
                        column: x => x.OnSaleId,
                        principalTable: "OnSale",
                        principalColumn: "OnSaleId");
                    table.ForeignKey(
                        name: "FK_Product_TopSell_TopSellId",
                        column: x => x.TopSellId,
                        principalTable: "TopSell",
                        principalColumn: "TopSellId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_DofweekId",
                table: "HomeProduct",
                column: "DofweekId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_LastestProductId",
                table: "HomeProduct",
                column: "LastestProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_NewArrId",
                table: "HomeProduct",
                column: "NewArrId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_OnSaleId",
                table: "HomeProduct",
                column: "OnSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeProduct_TopSellId",
                table: "HomeProduct",
                column: "TopSellId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DofweekId",
                table: "Product",
                column: "DofweekId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LastestProductId",
                table: "Product",
                column: "LastestProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_NewArrId",
                table: "Product",
                column: "NewArrId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OnSaleId",
                table: "Product",
                column: "OnSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TopSellId",
                table: "Product",
                column: "TopSellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Dofweek");

            migrationBuilder.DropTable(
                name: "LastestProduct");

            migrationBuilder.DropTable(
                name: "NewArr");

            migrationBuilder.DropTable(
                name: "OnSale");

            migrationBuilder.DropTable(
                name: "TopSell");
        }
    }
}
