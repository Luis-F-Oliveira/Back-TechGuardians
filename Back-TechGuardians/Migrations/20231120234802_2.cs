using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_TechGuardians.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitorings_Users_UserModelId",
                table: "Monitorings");

            migrationBuilder.DropIndex(
                name: "IX_Monitorings_UserModelId",
                table: "Monitorings");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Monitorings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Monitorings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_UserModelId",
                table: "Monitorings",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorings_Users_UserModelId",
                table: "Monitorings",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
