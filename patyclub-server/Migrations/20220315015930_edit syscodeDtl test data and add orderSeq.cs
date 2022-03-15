using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class editsyscodeDtltestdataandaddorderSeq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderSeq",
                table: "SYS_CODE_DTL",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 3,
                column: "orderSeq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 4,
                column: "orderSeq",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 5,
                column: "orderSeq",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 6,
                column: "orderSeq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 7,
                column: "orderSeq",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 8,
                column: "orderSeq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 9,
                column: "orderSeq",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 10,
                column: "orderSeq",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 11,
                column: "orderSeq",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 12,
                column: "orderSeq",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 13,
                column: "orderSeq",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumn: "id",
                keyValue: 14,
                column: "orderSeq",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "ageLimit",
                columns: new[] { "name", "remark" },
                values: new object[] { "年齡限制分級", "" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventPersonnel",
                columns: new[] { "name", "remark" },
                values: new object[] { "活動人員身分別", "" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventStatus",
                columns: new[] { "name", "remark" },
                values: new object[] { "活動狀態代碼", "" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventTag",
                columns: new[] { "name", "remark" },
                values: new object[] { "活動標記代碼", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderSeq",
                table: "SYS_CODE_DTL");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "ageLimit",
                columns: new[] { "name", "remark" },
                values: new object[] { "ageLimit", "年齡限制分級" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventPersonnel",
                columns: new[] { "name", "remark" },
                values: new object[] { "EventPersonnelPermission", "活動人員權限" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventStatus",
                columns: new[] { "name", "remark" },
                values: new object[] { "eventStatus", "活動狀態代碼" });

            migrationBuilder.UpdateData(
                table: "SYS_CODE_MST",
                keyColumn: "keyword",
                keyValue: "eventTag",
                columns: new[] { "name", "remark" },
                values: new object[] { "TAG", "活動標記代碼" });
        }
    }
}
