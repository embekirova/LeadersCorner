using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadersCorner.Data.Migrations
{
    public partial class UserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManagerOrLeader",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManagerOrLeader",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "AspNetUsers");
        }
    }
}
