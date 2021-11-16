using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class UserAddforgetPwdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "forgetPwdToken",
                table: "USER",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "forgetPwdTokenCreatedDate",
                table: "USER",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "forgetPwdToken",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "forgetPwdTokenCreatedDate",
                table: "USER");
        }
    }
}
