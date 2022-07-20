using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_try6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_SystemRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SystemRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemRoleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SystemRoleId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_SystemRoleId",
                table: "AspNetRoles",
                column: "SystemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_SystemUserId",
                table: "AspNetRoles",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_SystemRoleId",
                table: "AspNetRoles",
                column: "SystemRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_SystemUserId",
                table: "AspNetRoles",
                column: "SystemUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_SystemRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_SystemUserId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_SystemRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_SystemUserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SystemRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "SystemRoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SystemRoleId",
                table: "AspNetUsers",
                column: "SystemRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_SystemRoleId",
                table: "AspNetUsers",
                column: "SystemRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
