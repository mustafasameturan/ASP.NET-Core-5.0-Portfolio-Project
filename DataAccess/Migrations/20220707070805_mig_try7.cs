using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_try7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "SystemUserRolesRoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemUserRolesUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SystemUserRolesUserId_SystemUserRolesRoleId",
                table: "AspNetUsers",
                columns: new[] { "SystemUserRolesUserId", "SystemUserRolesRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUserRoles_SystemUserRolesUserId_SystemUserRolesRoleId",
                table: "AspNetUsers",
                columns: new[] { "SystemUserRolesUserId", "SystemUserRolesRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUserRoles_SystemUserRolesUserId_SystemUserRolesRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SystemUserRolesUserId_SystemUserRolesRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemUserRolesRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SystemUserRolesUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

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
    }
}
