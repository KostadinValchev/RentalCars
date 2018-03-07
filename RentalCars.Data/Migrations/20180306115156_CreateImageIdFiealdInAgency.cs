namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreateImageIdFiealdInAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Agencies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Agencies");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Cars",
                nullable: true);
        }
    }
}
