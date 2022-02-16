using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3.Data.Migrations
{
    public partial class updatedpersonalno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNo",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PersonalNo",
                table: "Member",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id");
        }
    }
}
