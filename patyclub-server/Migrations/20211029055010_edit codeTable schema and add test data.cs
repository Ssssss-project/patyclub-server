using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class editcodeTableschemaandaddtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "enable",
                table: "EVENT_CATEGORY",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 1,
                column: "enable",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 2,
                column: "enable",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 3,
                column: "enable",
                value: "Y");

            migrationBuilder.UpdateData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 4,
                column: "enable",
                value: "Y");

            migrationBuilder.InsertData(
                table: "EVENT_CATEGORY",
                columns: new[] { "id", "categoryName", "enable", "parentId" },
                values: new object[] { 5, "測試活動A-3", "N", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "enable",
                table: "EVENT_CATEGORY");
        }
    }
}
