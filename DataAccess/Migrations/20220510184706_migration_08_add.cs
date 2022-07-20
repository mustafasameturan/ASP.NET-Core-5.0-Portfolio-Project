using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration_08_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ContactInformations",
                newName: "DiscordID");

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "ContactInformations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "ContactInformations");

            migrationBuilder.RenameColumn(
                name: "DiscordID",
                table: "ContactInformations",
                newName: "PhoneNumber");
        }
    }
}
