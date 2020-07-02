using Microsoft.EntityFrameworkCore.Migrations;

namespace IOTManagementApp.Data.Migrations
{
    public partial class userIDFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_UserId1",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId1",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Devices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Devices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId1",
                table: "Devices",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_UserId1",
                table: "Devices",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
