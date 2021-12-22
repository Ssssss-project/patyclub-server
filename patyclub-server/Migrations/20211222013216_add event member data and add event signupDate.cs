using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addeventmemberdataandaddeventsignupDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "signUpEdDate",
                table: "EVENT_MST",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "signUpStDate",
                table: "EVENT_MST",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "tag",
                value: "S");

            migrationBuilder.InsertData(
                table: "EVENT_PERSONNEL",
                columns: new[] { "eventMstId", "userAccount", "permission", "status" },
                values: new object[,]
                {
                    { 1, "adda", "OWNER", "??" },
                    { 1, "yiyuan", "MEMBER", "??" },
                    { 1, "peng", "MEMBER", "??" },
                    { 2, "yiyuan", "OWNER", "??" },
                    { 2, "peng", "MEMBER", "??" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "sysCodeMstId", "codeDesc", "codeName" },
                values: new object[,]
                {
                    { 6, 3, "擁有者", "OWNER" },
                    { 7, 3, "成員", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_MST",
                columns: new[] { "id", "name", "remark" },
                values: new object[] { 3, "EventPersonnelPermission", "活動人員權限" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_PERSONNEL",
                keyColumns: new[] { "eventMstId", "userAccount" },
                keyValues: new object[] { 1, "adda" });

            migrationBuilder.DeleteData(
                table: "EVENT_PERSONNEL",
                keyColumns: new[] { "eventMstId", "userAccount" },
                keyValues: new object[] { 1, "peng" });

            migrationBuilder.DeleteData(
                table: "EVENT_PERSONNEL",
                keyColumns: new[] { "eventMstId", "userAccount" },
                keyValues: new object[] { 2, "peng" });

            migrationBuilder.DeleteData(
                table: "EVENT_PERSONNEL",
                keyColumns: new[] { "eventMstId", "userAccount" },
                keyValues: new object[] { 1, "yiyuan" });

            migrationBuilder.DeleteData(
                table: "EVENT_PERSONNEL",
                keyColumns: new[] { "eventMstId", "userAccount" },
                keyValues: new object[] { 2, "yiyuan" });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_MST",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "signUpEdDate",
                table: "EVENT_MST");

            migrationBuilder.DropColumn(
                name: "signUpStDate",
                table: "EVENT_MST");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "tag",
                value: "H");
        }
    }
}
