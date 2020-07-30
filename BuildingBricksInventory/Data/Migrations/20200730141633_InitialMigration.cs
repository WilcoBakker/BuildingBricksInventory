using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingBricksInventory.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bricks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bricks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegoSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegoCollectionBricks",
                columns: table => new
                {
                    BrickId = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoCollectionBricks", x => x.BrickId);
                    table.ForeignKey(
                        name: "FK_LegoCollectionBricks_Bricks_BrickId",
                        column: x => x.BrickId,
                        principalTable: "Bricks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegoCollectionSets",
                columns: table => new
                {
                    SetId = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoCollectionSets", x => x.SetId);
                    table.ForeignKey(
                        name: "FK_LegoCollectionSets_LegoSets_SetId",
                        column: x => x.SetId,
                        principalTable: "LegoSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegoSetBricks",
                columns: table => new
                {
                    SetId = table.Column<int>(nullable: false),
                    BrickId = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoSetBricks", x => new { x.SetId, x.BrickId });
                    table.ForeignKey(
                        name: "FK_LegoSetBricks_Bricks_BrickId",
                        column: x => x.BrickId,
                        principalTable: "Bricks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegoSetBricks_LegoSets_SetId",
                        column: x => x.SetId,
                        principalTable: "LegoSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bricks",
                columns: new[] { "Id", "Color", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3039, "Red", "/Brick1.jpg", "Slope Brick 2 x 2, 45 Degrees" },
                    { 4445, "Red", "/Brick2.jpg", "Slope Brick 45 2 x 8" },
                    { 3003, "Yellow", "/Brick3.jpg", "Brick 2 x 2" },
                    { 3022, "Black", "/Brick4.jpg", "Plate 2 x 2" },
                    { 3010, "Yellow", "/Brick5.jpg", "Brick 1 x 4" }
                });

            migrationBuilder.InsertData(
                table: "LegoSets",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 6360, "/Set6360.jpg", "LEGO 6360 Weekend Cottage" },
                    { 6365, "/Set6365.jpg", "LEGO 6365 Summer Cottage" },
                    { 6349, "/Set6349.jpg", "Lego 6349 Vacation House" }
                });

            migrationBuilder.InsertData(
                table: "LegoCollectionBricks",
                columns: new[] { "BrickId", "Amount" },
                values: new object[,]
                {
                    { 4445, 7L },
                    { 3003, 1L }
                });

            migrationBuilder.InsertData(
                table: "LegoCollectionSets",
                columns: new[] { "SetId", "Amount" },
                values: new object[] { 6365, 1L });

            migrationBuilder.InsertData(
                table: "LegoSetBricks",
                columns: new[] { "SetId", "BrickId", "Amount" },
                values: new object[,]
                {
                    { 6360, 3039, 6L },
                    { 6360, 4445, 7L },
                    { 6360, 3003, 5L },
                    { 6360, 3022, 1L },
                    { 6360, 3010, 2L },
                    { 6365, 3039, 8L },
                    { 6365, 3003, 2L },
                    { 6365, 3022, 1L },
                    { 6365, 3010, 7L },
                    { 6349, 3039, 4L },
                    { 6349, 4445, 4L },
                    { 6349, 3003, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegoSetBricks_BrickId",
                table: "LegoSetBricks",
                column: "BrickId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegoCollectionBricks");

            migrationBuilder.DropTable(
                name: "LegoCollectionSets");

            migrationBuilder.DropTable(
                name: "LegoSetBricks");

            migrationBuilder.DropTable(
                name: "Bricks");

            migrationBuilder.DropTable(
                name: "LegoSets");
        }
    }
}
