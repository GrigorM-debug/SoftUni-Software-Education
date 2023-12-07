using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventMI.Infrastructure.Migrations
{
    public partial class MaxLengthOnEventPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Място на провеждане",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Място на провеждане");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Място на провеждане",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Място на провеждане");
        }
    }
}
