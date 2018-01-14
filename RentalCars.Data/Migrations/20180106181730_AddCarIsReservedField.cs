namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCarIsReservedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingCount",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "BookingCount",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }
    }
}
