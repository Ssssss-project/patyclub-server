using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace patyclub_server.Migrations
{
    public partial class editclientLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENT_VIEW_LOG");

            migrationBuilder.CreateTable(
                name: "CLIENT_LOG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userAccount = table.Column<string>(type: "text", nullable: true),
                    targetSeq = table.Column<string>(type: "text", nullable: true),
                    logCategory = table.Column<string>(type: "text", nullable: true),
                    logDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_LOG", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "CLIENT_LOG",
                columns: new[] { "id", "logCategory", "logDate", "targetSeq", "userAccount" },
                values: new object[,]
                {
                    { 1, "eventTouch", "2021/12/3 09:25:36", "1", "adda" },
                    { 2, "eventTouch", "2021/12/4 08:45:23", "1", "adda" },
                    { 3, "eventTouch", "2021/12/8 05:25:28", "1", "adda" },
                    { 4, "eventTouch", "2021/12/9 20:12:34", "1", "adda" },
                    { 5, "eventTouch", "2021/12/5 23:53:14", "1", "adda" },
                    { 6, "eventTouch", "2021/12/7 10:01:02", "1", "adda" },
                    { 7, "eventTouch", "2021/12/5 01:42:51", "1", "adda" },
                    { 8, "eventTouch", "2021/12/5 13:12:44", "1", "adda" },
                    { 9, "eventTouch", "2021/12/1 15:32:12", "1", "adda" },
                    { 10, "eventTouch", "2021/12/2 18:42:31", "1", "adda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENT_LOG");

            migrationBuilder.CreateTable(
                name: "EVENT_VIEW_LOG",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    viewDate = table.Column<string>(type: "text", nullable: true),
                    viewSeq = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_VIEW_LOG", x => new { x.userAccount, x.eventMstId });
                });
        }
    }
}
