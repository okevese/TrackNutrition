using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackNutrition.Data.Migrations
{
    public partial class AddNutrientsUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Nutrients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Nutrients");
        }
    }
}
