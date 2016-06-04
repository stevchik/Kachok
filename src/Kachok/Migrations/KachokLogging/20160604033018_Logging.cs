using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kachok.Migrations.KachokLogging
{
    public partial class Logging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Browser = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    HostAddress = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: false),
                    Logger = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    RequestID = table.Column<string>(nullable: true),
                    Thread = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLog");
        }
    }
}
