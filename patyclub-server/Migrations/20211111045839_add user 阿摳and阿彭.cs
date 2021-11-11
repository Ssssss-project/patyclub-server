using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class adduser阿摳and阿彭 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "account",
                keyValue: "admin",
                column: "email",
                value: "patyclub9453@gmail.com");

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "account", "accountStatus", "activeState", "birthday", "city", "country", "email", "emotionalState", "introduction", "name", "nickName", "password", "phone", "photoStickerPath", "sex" },
                values: new object[,]
                {
                    { "pang", "Active", null, null, null, null, "cxz0917001997@gmail.com", null, null, "阿彭", null, "pang", null, null, null },
                    { "yiyuan", "Active", null, null, null, null, "charles01270@gmail.com", null, null, "阿摳", null, "yiyuan", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "pang");

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "yiyuan");

            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "account",
                keyValue: "admin",
                column: "email",
                value: null);
        }
    }
}
