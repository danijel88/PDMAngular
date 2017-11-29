using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDMAngular.Migrations
{
    public partial class AddFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemHists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Band = table.Column<decimal>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Elastic = table.Column<bool>(nullable: false),
                    Enter = table.Column<decimal>(nullable: true),
                    Exit = table.Column<decimal>(nullable: true),
                    InternalCode = table.Column<string>(maxLength: 50, nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    MachineTypeId = table.Column<int>(nullable: false),
                    MadeBy = table.Column<string>(maxLength: 150, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Thickness = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemHists_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemHists_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemHists_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_InternalCode",
                table: "Items",
                column: "InternalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_MadeBy",
                table: "Items",
                column: "MadeBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHists_ItemId",
                table: "ItemHists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHists_ItemTypeId",
                table: "ItemHists",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHists_MachineTypeId",
                table: "ItemHists",
                column: "MachineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemHists");

            migrationBuilder.DropIndex(
                name: "IX_Items_InternalCode",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MadeBy",
                table: "Items");
        }
    }
}
