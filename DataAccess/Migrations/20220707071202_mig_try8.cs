using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_try8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
