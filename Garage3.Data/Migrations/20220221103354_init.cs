using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_VehicleType_VehicleTypeId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_VehicleTypeId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Member");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_VehicleTypeId",
                table: "Member",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_VehicleType_VehicleTypeId",
                table: "Member",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }
    }
}
