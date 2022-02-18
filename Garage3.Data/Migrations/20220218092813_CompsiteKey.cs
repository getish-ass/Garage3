using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3.Data.Migrations
{
    public partial class CompsiteKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Name",
                table: "Name");

            migrationBuilder.DropIndex(
                name: "IX_Name_MemberId",
                table: "Name");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Name",
                table: "Name",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Name",
                table: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Name",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Name",
                table: "Name",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Name_MemberId",
                table: "Name",
                column: "MemberId",
                unique: true);
        }
    }
}
