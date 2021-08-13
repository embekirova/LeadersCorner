using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadersCorner.Data.Migrations
{
    public partial class IdentityRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "AspNetUsers");
        }
    }
}
