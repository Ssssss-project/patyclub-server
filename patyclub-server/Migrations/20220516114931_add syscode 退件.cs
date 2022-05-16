using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addsyscode退件 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "codeDesc", "codeName", "orderSeq", "sysCodeMstKeyword" },
                values: new object[] { 15, "退件", "AUDIT_REJECT", 4, "eventStatus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 15);
        }
    }
}
