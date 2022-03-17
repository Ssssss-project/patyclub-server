using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class editlogtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 3,
                column: "targetSeq",
                value: "2");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "targetSeq", "userAccount" },
                values: new object[] { "4", "yiyuan" });

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 6,
                column: "targetSeq",
                value: "3");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 7,
                column: "targetSeq",
                value: "2");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 8,
                column: "targetSeq",
                value: "3");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 10,
                column: "targetSeq",
                value: "3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 3,
                column: "targetSeq",
                value: "1");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "targetSeq", "userAccount" },
                values: new object[] { "1", "adda" });

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 6,
                column: "targetSeq",
                value: "1");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 7,
                column: "targetSeq",
                value: "1");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 8,
                column: "targetSeq",
                value: "1");

            migrationBuilder.UpdateData(
                table: "CLIENT_LOG",
                keyColumn: "id",
                keyValue: 10,
                column: "targetSeq",
                value: "1");
        }
    }
}
