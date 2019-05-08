using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackNutrition.Data.Migrations
{
    public partial class AddDailyNutrients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutrients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Proteins = table.Column<string>(nullable: true),
                    ProteinQuantity = table.Column<int>(nullable: false),
                    Fruits = table.Column<string>(nullable: true),
                    FruitQuantity = table.Column<int>(nullable: false),
                    Oils = table.Column<string>(nullable: true),
                    OilQuantity = table.Column<int>(nullable: false),
                    Dairy = table.Column<string>(nullable: true),
                    DairyQuantity = table.Column<int>(nullable: false),
                    Grains = table.Column<string>(nullable: true),
                    GrainQuantity = table.Column<int>(nullable: false),
                    Vegetables = table.Column<string>(nullable: true),
                    VegetableQuantity = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nutrients");
        }
    }
}
