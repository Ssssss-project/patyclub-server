using Microsoft.EntityFrameworkCore.Migrations;

namespace patyclub_server.Migrations
{
    public partial class addpermissionroleuserAppendix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "USER_APPENDIX",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "EVENT_APPENDIX",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "appendixPath",
                table: "EVENT_APPENDIX",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 1,
                column: "category",
                value: "K");

            migrationBuilder.InsertData(
                table: "AUTO_COMPLETE_LIST",
                columns: new[] { "id", "category", "content" },
                values: new object[,]
                {
                    { 13, "H", "#下海" },
                    { 12, "H", "#上山" },
                    { 11, "H", "#遠足" },
                    { 10, "H", "#百岳" },
                    { 9, "H", "#中級山" },
                    { 2, "K", "鳶嘴山" },
                    { 7, "H", "#ForFun" },
                    { 6, "K", "爬分" },
                    { 5, "K", "岩場地形" },
                    { 4, "K", "岩石" },
                    { 3, "K", "岩場" },
                    { 8, "H", "#積分" }
                });

            migrationBuilder.InsertData(
                table: "EVENT_APPENDIX",
                columns: new[] { "id", "appendixPath", "category", "eventMstId" },
                values: new object[,]
                {
                    { 4, "/Data/嘉義｜阿里山生態文化之旅.jpg", "P", 8 },
                    { 3, "/Data/LOL.jpg", "P", 7 },
                    { 2, "/Data/APEX.jpg", "P", 6 },
                    { 1, "/Data/鳶嘴山.jpg", "P", 1 }
                });

            migrationBuilder.InsertData(
                table: "MAPPING_PERMISSION_ROLE",
                columns: new[] { "permissionId", "roleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "MAPPING_USER_ROLE",
                columns: new[] { "roleId", "userAccount" },
                values: new object[,]
                {
                    { 1, "adda" },
                    { 1, "admin" },
                    { 2, "yiyuan" },
                    { 2, "pang" }
                });

            migrationBuilder.InsertData(
                table: "PERMISSION",
                columns: new[] { "id", "actionCategory", "functionName" },
                values: new object[,]
                {
                    { 1, "所有的權限", "總管理" },
                    { 2, "新增", "活動管理" },
                    { 3, "編輯", "活動管理" },
                    { 4, "刪除", "活動管理" }
                });

            migrationBuilder.InsertData(
                table: "USER_APPENDIX",
                columns: new[] { "id", "userAccount", "appendixPath", "category" },
                values: new object[] { 1, "yiyuan", "/Data/0.jpg", "H" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EVENT_APPENDIX",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EVENT_APPENDIX",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EVENT_APPENDIX",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EVENT_APPENDIX",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MAPPING_PERMISSION_ROLE",
                keyColumns: new[] { "permissionId", "roleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MAPPING_PERMISSION_ROLE",
                keyColumns: new[] { "permissionId", "roleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MAPPING_PERMISSION_ROLE",
                keyColumns: new[] { "permissionId", "roleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MAPPING_PERMISSION_ROLE",
                keyColumns: new[] { "permissionId", "roleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MAPPING_USER_ROLE",
                keyColumns: new[] { "roleId", "userAccount" },
                keyValues: new object[] { 1, "adda" });

            migrationBuilder.DeleteData(
                table: "MAPPING_USER_ROLE",
                keyColumns: new[] { "roleId", "userAccount" },
                keyValues: new object[] { 1, "admin" });

            migrationBuilder.DeleteData(
                table: "MAPPING_USER_ROLE",
                keyColumns: new[] { "roleId", "userAccount" },
                keyValues: new object[] { 2, "pang" });

            migrationBuilder.DeleteData(
                table: "MAPPING_USER_ROLE",
                keyColumns: new[] { "roleId", "userAccount" },
                keyValues: new object[] { 2, "yiyuan" });

            migrationBuilder.DeleteData(
                table: "PERMISSION",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PERMISSION",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PERMISSION",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PERMISSION",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "USER_APPENDIX",
                keyColumns: new[] { "id", "userAccount" },
                keyValues: new object[] { 1, "yiyuan" });

            migrationBuilder.DropColumn(
                name: "category",
                table: "USER_APPENDIX");

            migrationBuilder.AlterColumn<int>(
                name: "category",
                table: "EVENT_APPENDIX",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "appendixPath",
                table: "EVENT_APPENDIX",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AUTO_COMPLETE_LIST",
                keyColumn: "id",
                keyValue: 1,
                column: "category",
                value: "常用搜尋詞");
        }
    }
}
