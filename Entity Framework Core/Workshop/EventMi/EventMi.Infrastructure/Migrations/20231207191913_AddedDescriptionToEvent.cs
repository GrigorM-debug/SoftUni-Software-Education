using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventMi.Infrastructure.Migrations
{
    public partial class AddedDescriptionToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                comment: "Описание на събитието");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");
        }
    }
}
