using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class fixeventMstattributename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_AUDIT_LOG",
                keyColumns: new[] { "auditSeq", "auditTarget", "eventId" },
                keyValues: new object[] { 2, "eventAttantion", 1 });

            migrationBuilder.RenameColumn(
                name: "eventAttantion",
                table: "EVENT_MST",
                newName: "eventAttention");

            migrationBuilder.InsertData(
                table: "EVENT_AUDIT_LOG",
                columns: new[] { "auditSeq", "auditTarget", "eventId", "auditMessage", "createdDate" },
                values: new object[] { 2, "eventAttention", 1, "我是意見22", "2021/12/4 09:22:36" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_AUDIT_LOG",
                keyColumns: new[] { "auditSeq", "auditTarget", "eventId" },
                keyValues: new object[] { 2, "eventAttention", 1 });

            migrationBuilder.RenameColumn(
                name: "eventAttention",
                table: "EVENT_MST",
                newName: "eventAttantion");

            migrationBuilder.InsertData(
                table: "EVENT_AUDIT_LOG",
                columns: new[] { "auditSeq", "auditTarget", "eventId", "auditMessage", "createdDate" },
                values: new object[] { 2, "eventAttantion", 1, "我是意見22", "2021/12/4 09:22:36" });
        }
    }
}
