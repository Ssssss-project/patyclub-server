using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class editsampleeventandeventTAGGtoS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2,
                column: "tag",
                value: "S");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3,
                column: "tag",
                value: "S");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4,
                column: "tag",
                value: "S");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 8,
                column: "tag",
                value: "S");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 11,
                column: "tag",
                value: "S");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 2, 1 },
                column: "codeName",
                value: "S");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2,
                column: "tag",
                value: "G");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3,
                column: "tag",
                value: "G");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4,
                column: "tag",
                value: "G");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 8,
                column: "tag",
                value: "");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 11,
                column: "tag",
                value: "");

            migrationBuilder.UpdateData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 2, 1 },
                column: "codeName",
                value: "G");
        }
    }
}
