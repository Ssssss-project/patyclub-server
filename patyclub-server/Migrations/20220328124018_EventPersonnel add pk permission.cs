using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class EventPersonneladdpkpermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EVENT_PERSONNEL",
                table: "EVENT_PERSONNEL");

            migrationBuilder.AlterColumn<string>(
                name: "permission",
                table: "EVENT_PERSONNEL",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EVENT_PERSONNEL",
                table: "EVENT_PERSONNEL",
                columns: new[] { "userAccount", "eventMstId", "permission" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EVENT_PERSONNEL",
                table: "EVENT_PERSONNEL");

            migrationBuilder.AlterColumn<string>(
                name: "permission",
                table: "EVENT_PERSONNEL",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EVENT_PERSONNEL",
                table: "EVENT_PERSONNEL",
                columns: new[] { "userAccount", "eventMstId" });
        }
    }
}
