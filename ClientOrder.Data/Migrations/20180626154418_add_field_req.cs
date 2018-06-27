using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientOrder.Data.Migrations
{
    public partial class add_field_req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
