using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addeventAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENT_AUDIT_LOG",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "integer", nullable: false),
                    auditSeq = table.Column<int>(type: "integer", nullable: false),
                    auditTarget = table.Column<string>(type: "text", nullable: false),
                    auditMessage = table.Column<string>(type: "text", nullable: true),
                    createdDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_AUDIT_LOG", x => new { x.eventId, x.auditSeq, x.auditTarget });
                });

            migrationBuilder.InsertData(
                table: "EVENT_AUDIT_LOG",
                columns: new[] { "auditSeq", "auditTarget", "eventId", "auditMessage", "createdDate" },
                values: new object[,]
                {
                    { 1, "eventTitle", 1, "我是意見1", "2021/12/3 09:25:36" },
                    { 1, "categoryId", 1, "我是意見2", "2021/12/3 09:22:36" },
                    { 1, "eventStDate", 1, "我是意見3", "2021/12/3 09:21:36" },
                    { 1, "eventIntroduction", 1, "我是意見4", "2021/12/3 09:26:36" },
                    { 1, "cost", 1, "我是意見5", "2021/12/3 09:27:36" },
                    { 1, "signUpStDate", 1, "我是意見6", "2021/12/3 09:28:36" },
                    { 2, "eventTitle", 1, "我是意見11", "2021/12/4 09:23:36" },
                    { 2, "eventAttantion", 1, "我是意見22", "2021/12/4 09:22:36" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENT_AUDIT_LOG");
        }
    }
}
