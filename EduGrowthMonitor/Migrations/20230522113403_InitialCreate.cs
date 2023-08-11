using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduGrowthMonitor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EduProgressRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deatils = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduProgressRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduProgressRecord");
        }
    }
}
