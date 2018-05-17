using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webjs.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "newsModels",
                columns: table => new
                {
                    Url = table.Column<string>(nullable: false),
                    Header = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    TimeOf = table.Column<DateTime>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsModels", x => x.Url);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newsModels");
        }
    }
}
