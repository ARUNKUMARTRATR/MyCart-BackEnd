using Microsoft.EntityFrameworkCore.Migrations;

namespace Experion.MyCart.Data.Migrations
{
    public partial class mycart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catogory",
                columns: table => new
                {
                    CatogoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catogory = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogory", x => x.CatogoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(maxLength: 20, nullable: false),
                    L_Name = table.Column<string>(maxLength: 20, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    IsPremium = table.Column<bool>(nullable: true),
                    MobileNo = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    PhotoUrl = table.Column<string>(maxLength: 250, nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    LaunchDate = table.Column<string>(maxLength: 20, nullable: true),
                    Photo_Url = table.Column<string>(maxLength: 100, nullable: true),
                    IsAvailable = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CatogoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Catogory",
                        column: x => x.CatogoryId,
                        principalTable: "Catogory",
                        principalColumn: "CatogoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CartProductId = table.Column<string>(maxLength: 50, nullable: false),
                    ProductCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCart_Products",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCart_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Catogory",
                columns: new[] { "CatogoryId", "Catogory" },
                values: new object[] { 1, "electronics" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatogoryId", "Description", "IsAvailable", "IsDeleted", "LaunchDate", "Photo_Url", "Price", "ProductId", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/1.jpg", 44000.0, "mobile1", "OnePlus 7 Pro" },
                    { 2, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/2.jpg", 44000.0, "mobile2", "OnePlus 7 Pro" },
                    { 3, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/3.jpg", 44000.0, "mobile3", "OnePlus 7 Pro" },
                    { 4, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/4.jpg", 44000.0, "mobile4", "OnePlus 7 Pro" },
                    { 5, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/5.jpg", 44000.0, "mobile5", "OnePlus 7 Pro" },
                    { 6, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/6.jpg", 44000.0, "mobile6", "OnePlus 7 Pro" },
                    { 7, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/7.jpg", 44000.0, "mobile7", "OnePlus 7 Pro" },
                    { 8, 1, "Best mobiles under 50000", true, false, "2020-04-07", "assets/8.jpg", 44000.0, "mobile8", "OnePlus 7 Pro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_UserId",
                table: "ProductCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatogoryId",
                table: "Products",
                column: "CatogoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCart");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Catogory");
        }
    }
}
