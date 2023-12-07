using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventMI.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на събитие")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Име на събитие"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Начало на събитието"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Край на събитието"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Статус на събитието"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Дата на изтриване"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Място на провеждане")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                },
                comment: "Събитие");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
