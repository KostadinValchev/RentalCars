namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingImgUrlColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Cars");
        }
    }
}
