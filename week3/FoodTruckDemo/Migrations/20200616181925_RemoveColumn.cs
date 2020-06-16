using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckDemo.Migrations
{
    public partial class RemoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTruckId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "FoodTruckId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTruckId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "FoodTruckId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
