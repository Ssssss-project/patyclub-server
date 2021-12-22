using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ACHIEVEMENT",
                columns: new[] { "id", "describe", "goal" },
                values: new object[] { 1, "連續登入10天", 10 });

            migrationBuilder.InsertData(
                table: "AUTO_COMPLETE_LIST",
                columns: new[] { "id", "category", "content" },
                values: new object[] { 1, "常用搜尋詞", "patyclub" });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "系統管理員" },
                    { 2, "一般使用者" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "account", "accountStatus", "activeState", "birthday", "city", "country", "email", "emotionalState", "introduction", "name", "nickName", "password", "phone", "photoStickerPath", "sex" },
                values: new object[,]
                {
                    { "adda", "Active", null, null, null, null, null, null, null, "阿達", null, "adda", null, null, null },
                    { "admin", "Active", null, null, null, null, null, null, null, "阿管", null, "admin", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACHIEVEMENT",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "adda");

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "admin");
        }
    }
}
