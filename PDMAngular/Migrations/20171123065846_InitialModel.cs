using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDMAngular.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "MachineTypes");
        }
    }
}
