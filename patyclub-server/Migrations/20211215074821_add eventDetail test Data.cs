using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addeventDetailtestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventPrecaution",
                table: "EVENT_MST");

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "eventDetail",
                value: "日期：2021/03/20（六）\r\n天氣：晴☀️\r\n人數：阿寶、陳先生、毛毛，3人皆常爬山\r\n難度：中\r\n距離：全程2.1公里（27k上、27.3k下）\r\n時程：3小時45分\r\n07:45 27k登山口\r\n08:00 鳶嘴山/橫嶺山岔口\r\n08:25 二葉松涼亭\r\n09:10 鳶嘴山\r\n09:30 開始下山\r\n10:30 結束拉繩陡下\r\n10:45 稍來山/大雪山林道岔口\r\n11:30 27.3k登山口\r\n\r\n喝水800ml");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eventPrecaution",
                table: "EVENT_MST",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EVENT_MST",
                keyColumn: "id",
                keyValue: 1,
                column: "eventDetail",
                value: null);
        }
    }
}
