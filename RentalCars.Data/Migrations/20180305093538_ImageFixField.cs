using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RentalCars.Data.Migrations
{
    public partial class ImageFixField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Agencies_AgencyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AgencyId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Images_AgencyId",
                table: "Images",
                column: "AgencyId",
                unique: true,
                filter: "[AgencyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Agencies_AgencyId",
                table: "Images",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Agencies_AgencyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AgencyId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "AgencyId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
