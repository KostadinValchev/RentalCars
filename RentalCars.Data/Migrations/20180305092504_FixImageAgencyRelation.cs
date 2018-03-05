using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RentalCars.Data.Migrations
{
    public partial class FixImageAgencyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Images_ImageId",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_ImageId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Agencies");

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AgencyId",
                table: "Images",
                column: "AgencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Agencies_AgencyId",
                table: "Images",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Agencies_AgencyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AgencyId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Agencies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_ImageId",
                table: "Agencies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Images_ImageId",
                table: "Agencies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
