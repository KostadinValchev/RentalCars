namespace RentalCars.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AgencyLogoPropertyForCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyLogoId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AgencyLogoId",
                table: "Cars",
                column: "AgencyLogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Images_AgencyLogoId",
                table: "Cars",
                column: "AgencyLogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Images_AgencyLogoId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AgencyLogoId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AgencyLogoId",
                table: "Cars");
        }
    }
}
