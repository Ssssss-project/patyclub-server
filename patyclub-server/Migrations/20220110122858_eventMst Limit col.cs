using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class eventMstLimitcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ageLimit",
                table: "EVENT_MST",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "personLimit",
                table: "EVENT_MST",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "personLimit",
                value: 10);

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "ageLimit", "personLimit" },
                values: new object[] { ">15", 6 });

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "ageLimit", "personLimit" },
                values: new object[] { ">6", 8 });

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4,
                column: "ageLimit",
                value: ">15");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 5,
                column: "ageLimit",
                value: ">18");

            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "sysCodeMstId", "codeDesc", "codeName" },
                values: new object[,]
                {
                    { 8, 4, "6-", "<6" },
                    { 9, 4, "6+", ">6" },
                    { 10, 4, "15+", ">15" },
                    { 11, 4, "18+", ">18" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_MST",
                columns: new[] { "id", "name", "remark" },
                values: new object[] { 4, "ageLimit", "年齡限制分級" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_MST",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ageLimit",
                table: "EVENT_MST");

            migrationBuilder.DropColumn(
                name: "personLimit",
                table: "EVENT_MST");
        }
    }
}
