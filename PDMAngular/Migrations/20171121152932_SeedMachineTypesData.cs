using Microsoft.EntityFrameworkCore.Migrations;

namespace PDMAngular.Migrations
{
    public partial class SeedMachineTypesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MachineTypes SELECT CreateDate,Description,Name,UpdateDate,UserId FROM  [PDM].[dbo].[MachineTypes]");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MachineTypes");
        }
    }
}
