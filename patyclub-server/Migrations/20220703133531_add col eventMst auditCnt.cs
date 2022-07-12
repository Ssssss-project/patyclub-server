using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addcoleventMstauditCnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "auditCnt",
                table: "EVENT_MST",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auditCnt",
                table: "EVENT_MST");
        }
    }
}
