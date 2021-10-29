using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class fixsomeschemaandaddtestevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "adda");

            migrationBuilder.AddColumn<string>(
                name: "eventTitle",
                table: "EVENT_MST",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "EVENT_CATEGORY",
                columns: new[] { "id", "categoryName", "parentId" },
                values: new object[] { 1, "測試活動A", 0 });

            migrationBuilder.InsertData(
                table: "EVENT_MST",
                columns: new[] { "id", "categoryId", "cost", "eventAttantion", "eventCreateDate", "eventDetail", "eventEdDate", "eventIntroduction", "eventPrecaution", "eventStDate", "eventTitle", "examinationPassedDate", "status", "tag" },
                values: new object[] { 1, 0, "1000", null, null, null, null, null, null, null, "爬爬爬爬爬山趣", null, "A", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "eventTitle",
                table: "EVENT_MST");

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "account", "accountStatus", "activeState", "birthday", "city", "country", "email", "emotionalState", "introduction", "name", "nickName", "password", "phone", "photoStickerPath", "sex" },
                values: new object[] { "adda", "Active", null, null, null, null, null, null, null, "阿達", null, "adda", null, null, null });
        }
    }
}
