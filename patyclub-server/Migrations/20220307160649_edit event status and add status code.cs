using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class editeventstatusandaddstatuscode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 5,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 6,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 7,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 8,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 9,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 10,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 11,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 12,
                column: "status",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 3, 2 },
                column: "codeName",
                value: "TEMP");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "codeDesc", "codeName" },
                values: new object[] { "已完成未送審", "COMPLETE" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 5, 2 },
                column: "codeName",
                value: "DELETE");

            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "sysCodeMstId", "codeDesc", "codeName" },
                values: new object[,]
                {
                    { 13, 2, "審核通過", "AUDIT_PASS" },
                    { 12, 2, "送審中", "AUDIT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 5,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 6,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 7,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 8,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 9,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 10,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 11,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 12,
                column: "status",
                value: "T");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 3, 2 },
                column: "codeName",
                value: "T");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "codeDesc", "codeName" },
                values: new object[] { "已取消", "C" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 5, 2 },
                column: "codeName",
                value: "D");
        }
    }
}
