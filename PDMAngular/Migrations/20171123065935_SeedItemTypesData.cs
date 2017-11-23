using Microsoft.EntityFrameworkCore.Migrations;

namespace PDMAngular.Migrations
{
    public partial class SeedItemTypesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ItemTypes SELECT CreateDate,Description,Name,UpdateDate,UserId FROM [PDM].[dbo].[ItemTypes]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ItemTypes");
        }
    }
}
