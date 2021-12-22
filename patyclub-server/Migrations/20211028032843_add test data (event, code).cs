using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addtestdataeventcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "SYS_CODE_DTL",
                newName: "codeName");

            migrationBuilder.AddColumn<string>(
                name: "codeDesc",
                table: "SYS_CODE_DTL",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "EVENT_CATEGORY",
                columns: new[] { "id", "categoryName", "parentId" },
                values: new object[,]
                {
                    { 2, "測試活動B", 0 },
                    { 3, "測試活動A-1", 1 },
                    { 4, "測試活動A-2", 1 }
                });

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "categoryId", "status", "tag" },
                values: new object[] { 3, "T", "H" });

            migrationBuilder.InsertData(
                table: "EVENT_MST",
                columns: new[] { "id", "categoryId", "cost", "eventAttantion", "eventCreateDate", "eventDetail", "eventEdDate", "eventIntroduction", "eventPrecaution", "eventStDate", "eventTitle", "examinationPassedDate", "status", "tag" },
                values: new object[,]
                {
                    { 3, 2, "1000", null, null, null, null, null, null, null, "SideProject Coding...", null, "T", "G" },
                    { 2, 3, "1000", null, null, null, null, null, null, null, "颱風天要幹嘛? 當然是去泛舟R!", null, "T", "G" },
                    { 11, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A6", null, "T", "" },
                    { 9, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A4", null, "T", "" },
                    { 8, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A3", null, "T", "" },
                    { 12, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A7", null, "T", "" },
                    { 6, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A1", null, "T", "" },
                    { 5, 4, "1000", null, null, null, null, null, null, null, "JustDance跳跳跳!", null, "T", "H" },
                    { 4, 1, "1000", null, null, null, null, null, null, null, "一日雙塔，騎起來~", null, "T", "G" },
                    { 7, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A2", null, "T", "" },
                    { 10, 4, "1000", null, null, null, null, null, null, null, "不想想活動名-A5", null, "T", "" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "sysCodeMstId", "codeDesc", "codeName" },
                values: new object[,]
                {
                    { 1, 1, "熱門活動", "H" },
                    { 2, 1, "精選活動", "G" },
                    { 3, 2, "暫存中", "T" },
                    { 4, 2, "已取消", "C" },
                    { 5, 2, "已刪除", "D" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_MST",
                columns: new[] { "id", "name", "remark" },
                values: new object[,]
                {
                    { 1, "TAG", "活動標記代碼" },
                    { 2, "eventStatus", "活動狀態代碼" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "account", "accountStatus", "activeState", "birthday", "city", "country", "email", "emotionalState", "introduction", "name", "nickName", "password", "phone", "photoStickerPath", "sex" },
                values: new object[] { "adda", "Active", null, null, null, null, null, null, null, "阿達", null, "adda", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EVENT_CATEGORY",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_DTL",
                keyColumns: new[] { "id", "sysCodeMstId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "SYS_CODE_MST",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SYS_CODE_MST",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "account",
                keyValue: "adda");

            migrationBuilder.DropColumn(
                name: "codeDesc",
                table: "SYS_CODE_DTL");

            migrationBuilder.RenameColumn(
                name: "codeName",
                table: "SYS_CODE_DTL",
                newName: "content");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "categoryId", "status", "tag" },
                values: new object[] { 0, "A", null });
        }
    }
}
