using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadersCorner.Data.Migrations
{
    public partial class UserNameC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Comments",
                newName: "UserFirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "Comments",
                newName: "FirstName");
        }
    }
}
