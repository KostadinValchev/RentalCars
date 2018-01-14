namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddBookingCountColumnInCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingCount",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingCount",
                table: "Cars");
        }
    }
}
