namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRentDaysAndPriceColumnInRentalOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RentalOrders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RentDays",
                table: "RentalOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RentalOrders");

            migrationBuilder.DropColumn(
                name: "RentDays",
                table: "RentalOrders");
        }
    }
}
