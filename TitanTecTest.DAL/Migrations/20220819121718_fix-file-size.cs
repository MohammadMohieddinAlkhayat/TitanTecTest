using Microsoft.EntityFrameworkCore.Migrations;

namespace TitanTecTest.DAL.Migrations
{
    public partial class fixfilesize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "EmployeeFiles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "EmployeeFiles",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
