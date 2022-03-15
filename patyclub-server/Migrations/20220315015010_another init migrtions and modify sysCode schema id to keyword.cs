using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace patyclub_server.Migrations
{
    public partial class anotherinitmigrtionsandmodifysysCodeschemaidtokeyword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACHIEVEMENT",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    describe = table.Column<string>(type: "text", nullable: true),
                    goal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACHIEVEMENT", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AUTO_COMPLETE_LIST",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTO_COMPLETE_LIST", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_LOG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userAccount = table.Column<string>(type: "text", nullable: true),
                    targetSeq = table.Column<string>(type: "text", nullable: true),
                    logCategory = table.Column<string>(type: "text", nullable: true),
                    logDate = table.Column<string>(type: "text", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    stauts = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_LOG", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EVENT_APPENDIX",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    appendixPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_APPENDIX", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EVENT_CATEGORY",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryName = table.Column<string>(type: "text", nullable: true),
                    parentId = table.Column<int>(type: "integer", nullable: false),
                    enable = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_CATEGORY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EVENT_COLLECT",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    eventMstId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_COLLECT", x => new { x.userAccount, x.eventMstId });
                });

            migrationBuilder.CreateTable(
                name: "EVENT_MST",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryId = table.Column<int>(type: "integer", nullable: false),
                    eventTitle = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<string>(type: "text", nullable: true),
                    eventStDate = table.Column<string>(type: "text", nullable: true),
                    eventEdDate = table.Column<string>(type: "text", nullable: true),
                    eventCreateDate = table.Column<string>(type: "text", nullable: true),
                    examinationPassedDate = table.Column<string>(type: "text", nullable: true),
                    signUpStDate = table.Column<string>(type: "text", nullable: true),
                    signUpEdDate = table.Column<string>(type: "text", nullable: true),
                    eventIntroduction = table.Column<string>(type: "text", nullable: true),
                    eventDetail = table.Column<string>(type: "text", nullable: true),
                    eventAttantion = table.Column<string>(type: "text", nullable: true),
                    tag = table.Column<string>(type: "text", nullable: true),
                    personLimit = table.Column<int>(type: "integer", nullable: false),
                    ageLimit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_MST", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EVENT_PERSONNEL",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    permission = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_PERSONNEL", x => new { x.userAccount, x.eventMstId });
                });

            migrationBuilder.CreateTable(
                name: "MAPPING_EVENT_TAG",
                columns: table => new
                {
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    tagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPPING_EVENT_TAG", x => new { x.eventMstId, x.tagId });
                });

            migrationBuilder.CreateTable(
                name: "MAPPING_PERMISSION_ROLE",
                columns: table => new
                {
                    permissionId = table.Column<int>(type: "integer", nullable: false),
                    roleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPPING_PERMISSION_ROLE", x => new { x.permissionId, x.roleId });
                });

            migrationBuilder.CreateTable(
                name: "MAPPING_USER_ACHIEVEMENT",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    achievementId = table.Column<int>(type: "integer", nullable: false),
                    currentProgress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPPING_USER_ACHIEVEMENT", x => new { x.userAccount, x.achievementId });
                });

            migrationBuilder.CreateTable(
                name: "MAPPING_USER_PERSONAL_SETTING",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    personalSettingId = table.Column<int>(type: "integer", nullable: false),
                    settingValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPPING_USER_PERSONAL_SETTING", x => new { x.userAccount, x.personalSettingId });
                });

            migrationBuilder.CreateTable(
                name: "MAPPING_USER_ROLE",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    roleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPPING_USER_ROLE", x => new { x.userAccount, x.roleId });
                });

            migrationBuilder.CreateTable(
                name: "NEWS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    context = table.Column<string>(type: "text", nullable: true),
                    tag = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    createdDate = table.Column<string>(type: "text", nullable: true),
                    lastUpdateDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    functionName = table.Column<string>(type: "text", nullable: true),
                    actionCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAL_SETTING",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAL_SETTING", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRATION_FORM",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    questionId = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRATION_FORM", x => new { x.userAccount, x.eventMstId, x.questionId });
                });

            migrationBuilder.CreateTable(
                name: "REGISTRATION_FORM_QUESTION",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventMstId = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRATION_FORM_QUESTION", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRATION_FORM_QUESTION_OPTION",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    questionId = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRATION_FORM_QUESTION_OPTION", x => new { x.questionId, x.id });
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_CODE_DTL",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sysCodeMstKeyword = table.Column<string>(type: "text", nullable: true),
                    codeName = table.Column<string>(type: "text", nullable: true),
                    codeDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_CODE_DTL", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_CODE_MST",
                columns: table => new
                {
                    keyword = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_CODE_MST", x => x.keyword);
                });

            migrationBuilder.CreateTable(
                name: "TAG_LIST",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tagName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_LIST", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    account = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    nickName = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    birthday = table.Column<string>(type: "text", nullable: true),
                    emotionalState = table.Column<string>(type: "text", nullable: true),
                    activeState = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    introduction = table.Column<string>(type: "text", nullable: true),
                    accountStatus = table.Column<string>(type: "text", nullable: true),
                    forgetPwdToken = table.Column<string>(type: "text", nullable: true),
                    forgetPwdTokenCreatedDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.account);
                });

            migrationBuilder.CreateTable(
                name: "USER_APPENDIX",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(type: "text", nullable: true),
                    appendixPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_APPENDIX", x => new { x.userAccount, x.id });
                });

            migrationBuilder.CreateTable(
                name: "USER_NOTIFY",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_NOTIFY", x => new { x.userAccount, x.id });
                });

            migrationBuilder.InsertData(
                table: "ACHIEVEMENT",
                columns: new[] { "id", "describe", "goal" },
                values: new object[] { 1, "連續登入10天", 10 });

            migrationBuilder.InsertData(
                table: "AUTO_COMPLETE_LIST",
                columns: new[] { "id", "category", "content" },
                values: new object[,]
                {
                    { 13, "H", "#下海" },
                    { 12, "H", "#上山" },
                    { 11, "H", "#遠足" },
                    { 10, "H", "#百岳" },
                    { 8, "H", "#積分" },
                    { 7, "H", "#ForFun" },
                    { 9, "H", "#中級山" },
                    { 5, "K", "岩場地形" },
                    { 4, "K", "岩石" },
                    { 3, "K", "岩場" },
                    { 2, "K", "鳶嘴山" },
                    { 1, "K", "patyclub" },
                    { 6, "K", "爬分" }
                });

            migrationBuilder.InsertData(
                table: "CLIENT_LOG",
                columns: new[] { "id", "logCategory", "logDate", "remark", "stauts", "targetSeq", "userAccount" },
                values: new object[,]
                {
                    { 7, "eventTouch", "2021/12/5 01:42:51", null, null, "1", "adda" },
                    { 10, "eventTouch", "2021/12/2 18:42:31", null, null, "1", "adda" },
                    { 9, "eventTouch", "2021/12/1 15:32:12", null, null, "1", "adda" },
                    { 8, "eventTouch", "2021/12/5 13:12:44", null, null, "1", "adda" },
                    { 6, "eventTouch", "2021/12/7 10:01:02", null, null, "1", "adda" },
                    { 5, "eventTouch", "2021/12/5 23:53:14", null, null, "1", "adda" },
                    { 4, "eventTouch", "2021/12/9 20:12:34", null, null, "1", "adda" },
                    { 3, "eventTouch", "2021/12/8 05:25:28", null, null, "1", "adda" },
                    { 2, "eventTouch", "2021/12/4 08:45:23", null, null, "1", "adda" },
                    { 1, "eventTouch", "2021/12/3 09:25:36", null, null, "1", "adda" }
                });

            migrationBuilder.InsertData(
                table: "EVENT_APPENDIX",
                columns: new[] { "id", "appendixPath", "category", "eventMstId" },
                values: new object[,]
                {
                    { 1, "/Data/鳶嘴山.jpg", "P", 1 },
                    { 2, "/Data/APEX.jpg", "P", 6 },
                    { 3, "/Data/LOL.jpg", "P", 7 },
                    { 4, "/Data/嘉義｜阿里山生態文化之旅.jpg", "P", 8 }
                });

            migrationBuilder.InsertData(
                table: "EVENT_CATEGORY",
                columns: new[] { "id", "categoryName", "enable", "parentId" },
                values: new object[,]
                {
                    { 5, "測試活動A-3", "N", 1 },
                    { 4, "測試活動A-2", "Y", 1 },
                    { 1, "測試活動A", "Y", 0 },
                    { 2, "測試活動B", "Y", 0 },
                    { 3, "測試活動A-1", "Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "EVENT_MST",
                columns: new[] { "id", "ageLimit", "categoryId", "cost", "eventAttantion", "eventCreateDate", "eventDetail", "eventEdDate", "eventIntroduction", "eventStDate", "eventTitle", "examinationPassedDate", "personLimit", "signUpEdDate", "signUpStDate", "status", "tag" },
                values: new object[,]
                {
                    { 8, null, 4, "1000", "要帶夠錢錢\r\n要帶水\r\n要帶健保卡", "2021/12/05", "記得攜帶個人所需物品\r\n天冷注意保暖", "2021/12/5", "阿里山鄉位於臺灣嘉義縣東部，北鄰南投縣竹山鎮，東鄰南投縣信義鄉、高雄市桃源區，西鄰梅山鄉、竹崎鄉、番路鄉，南接大埔鄉與高雄市那瑪夏區，是嘉義縣面積最大、人口密度最低的鄉鎮，其面積約佔全縣的1/5，也是嘉義縣唯一的山地鄉。", "2021/12/2", "阿里山郊遊趣", "", 0, null, null, "TEMP", "S" },
                    { 12, null, 4, "1000", "", "2021/12/02", "", "2021/12/8", "", "2021/12/8", "不想想活動名-A7", "", 0, null, null, "TEMP", "" },
                    { 10, null, 4, "1000", "", "2021/12/02", "", "2021/12/5", "", "2021/12/5", "不想想活動名-A5", "2021/12/2", 0, null, null, "TEMP", "" },
                    { 9, null, 4, "1000", "", "2021/12/01", "", "2021/12/8", "", "2021/12/3", "不想想活動名-A4", "", 0, null, null, "TEMP", "" },
                    { 7, null, 4, "1000", "for fun", "2021/12/01", "打到大家都累為止", "2021/12/26", "如題", "2021/12/25", "LOL NG隨便打", "2021/12/20", 0, null, null, "TEMP", "" },
                    { 11, null, 4, "1000", "", "2021/12/01", "", "2021/12/9", "", "2021/12/9", "不想想活動名-A6", "", 0, null, null, "TEMP", "S" },
                    { 5, ">18", 4, "1000", "", "2021/12/01", "", "2021/12/20", "", "2021/12/20", "JustDance跳跳跳!", "2021/12/10", 0, null, null, "TEMP", "H" },
                    { 1, null, 3, "1000", "【行前準備】\r\n\r\n1. 1500～2000cc 水\r\n\r\n2. 手套 （看個人非必要）有幾處需拉繩\r\n\r\n3. 穿登山鞋 或 較深紋路的鞋子\r\n\r\n4. 兩截式雨衣 （沒有的話就輕便雨衣）\r\n\r\n5. 長褲 （有彈性較佳）\r\n\r\n6. 身份證\r\n\r\n7. 午餐（麵包 or 御飯糰 之類）\r\n\r\n8. 帽子 （看個人非必要）\r\n\r\n9. 禦寒衣物\r\n\r\n10.小型後背包 \r\n\r\n11.一套乾淨衣服放車上回程如果有濕可換 \r\n\r\n12.衛生紙\r\n\r\n13.毛巾 （看個人非必要）", "2021/12/05", "日期：2021/03/20（六）\r\n天氣：晴☀️\r\n人數：阿寶、陳先生、毛毛，3人皆常爬山\r\n難度：中\r\n距離：全程2.1公里（27k上、27.3k下）\r\n時程：3小時45分\r\n07:45 27k登山口\r\n08:00 鳶嘴山/橫嶺山岔口\r\n08:25 二葉松涼亭\r\n09:10 鳶嘴山\r\n09:30 開始下山\r\n10:30 結束拉繩陡下\r\n10:45 稍來山/大雪山林道岔口\r\n11:30 27.3k登山口\r\n\r\n喝水800ml", "2021/12/31", "號稱台中最美的中級山-鳶嘴山，是台中登山旅遊的熱門景點，位在台中東勢，海拔2180公尺，險峻的峭壁危崖吸引許多喜歡冒險的登山者挑戰。\r\n\r\n對於初次挑戰者困難度稍高，建議有登山經驗的帶領會比較安全一點，登頂後的美麗風景讓人覺得一切真的都值得，有機會的話真的要來造訪一次", "2021/12/31", "爬爬爬爬爬山趣", "2021/12/10", 10, null, null, "TEMP", "S" },
                    { 2, ">15", 3, "1000", "", "2021/12/05", "", "2021/12/05", "", "2021/12/05", "颱風天要幹嘛? 當然是去泛舟R!", "2021/12/05", 6, null, null, "TEMP", "S" },
                    { 6, null, 4, "1000", "雷包勿來", "2021/12/02", "今天晚上五點開打\r\n打到白金為止", "2021/12/16", "銅牌一日上白金", "2021/12/15", "APEX 爬分", "", 0, null, null, "TEMP", "" },
                    { 4, ">15", 1, "1000", "", "2021/12/05", "", "2021/12/20", "", "2021/12/18", "一日雙塔，騎起來~", "", 0, null, null, "TEMP", "S" },
                    { 3, ">6", 2, "1000", "", "2021/12/01", "", "2021/12/17", "", "2021/12/15", "SideProject Coding...", "2021/12/10", 8, null, null, "TEMP", "S" }
                });

            migrationBuilder.InsertData(
                table: "EVENT_PERSONNEL",
                columns: new[] { "eventMstId", "userAccount", "permission", "status" },
                values: new object[,]
                {
                    { 1, "adda", "OWNER", "??" },
                    { 1, "yiyuan", "MEMBER", "??" },
                    { 1, "peng", "MEMBER", "??" },
                    { 2, "yiyuan", "OWNER", "??" },
                    { 2, "peng", "MEMBER", "??" }
                });

            migrationBuilder.InsertData(
                table: "MAPPING_PERMISSION_ROLE",
                columns: new[] { "permissionId", "roleId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 1 },
                    { 2, 2 }
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
                    { 4, "刪除", "活動管理" },
                    { 1, "所有的權限", "總管理" },
                    { 2, "新增", "活動管理" },
                    { 3, "編輯", "活動管理" }
                });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 2, "一般使用者" },
                    { 1, "系統管理員" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_DTL",
                columns: new[] { "id", "codeDesc", "codeName", "sysCodeMstKeyword" },
                values: new object[,]
                {
                    { 1, "熱門活動", "H", "eventTag" },
                    { 14, "關注者", "WATCHER", "eventPersonnel" },
                    { 13, "審核通過", "AUDIT_PASS", "eventStatus" },
                    { 11, "18+", ">18", "ageLimit" },
                    { 10, "15+", ">15", "ageLimit" },
                    { 9, "6+", ">6", "ageLimit" },
                    { 8, "6-", "<6", "ageLimit" },
                    { 12, "送審中", "AUDIT", "eventStatus" },
                    { 6, "擁有者", "OWNER", "eventPersonnel" },
                    { 5, "已刪除", "DELETE", "eventStatus" },
                    { 4, "已完成未送審", "COMPLETE", "eventStatus" },
                    { 3, "暫存中", "TEMP", "eventStatus" },
                    { 2, "精選活動", "S", "eventTag" },
                    { 7, "成員", "MEMBER", "eventPersonnel" }
                });

            migrationBuilder.InsertData(
                table: "SYS_CODE_MST",
                columns: new[] { "keyword", "name", "remark" },
                values: new object[,]
                {
                    { "eventTag", "TAG", "活動標記代碼" },
                    { "eventStatus", "eventStatus", "活動狀態代碼" },
                    { "eventPersonnel", "EventPersonnelPermission", "活動人員權限" },
                    { "ageLimit", "ageLimit", "年齡限制分級" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "account", "accountStatus", "activeState", "birthday", "city", "country", "email", "emotionalState", "forgetPwdToken", "forgetPwdTokenCreatedDate", "introduction", "name", "nickName", "password", "phone", "sex" },
                values: new object[,]
                {
                    { "pang", "Active", null, null, null, null, "cxz0917001997@gmail.com", null, null, null, null, "阿彭", null, "pang", null, null },
                    { "adda", "Active", null, null, null, null, null, null, null, null, null, "阿達", null, "adda", null, null },
                    { "admin", "Active", null, null, null, null, "patyclub9453@gmail.com", null, null, null, null, "阿管", null, "admin", null, null },
                    { "yiyuan", "Active", null, null, null, null, "charles01270@gmail.com", null, null, null, null, "阿摳", null, "yiyuan", null, null }
                });

            migrationBuilder.InsertData(
                table: "USER_APPENDIX",
                columns: new[] { "id", "userAccount", "appendixPath", "category" },
                values: new object[] { 1, "yiyuan", "/Data/0.jpg", "H" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACHIEVEMENT");

            migrationBuilder.DropTable(
                name: "AUTO_COMPLETE_LIST");

            migrationBuilder.DropTable(
                name: "CLIENT_LOG");

            migrationBuilder.DropTable(
                name: "EVENT_APPENDIX");

            migrationBuilder.DropTable(
                name: "EVENT_CATEGORY");

            migrationBuilder.DropTable(
                name: "EVENT_COLLECT");

            migrationBuilder.DropTable(
                name: "EVENT_MST");

            migrationBuilder.DropTable(
                name: "EVENT_PERSONNEL");

            migrationBuilder.DropTable(
                name: "MAPPING_EVENT_TAG");

            migrationBuilder.DropTable(
                name: "MAPPING_PERMISSION_ROLE");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_ACHIEVEMENT");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_PERSONAL_SETTING");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_ROLE");

            migrationBuilder.DropTable(
                name: "NEWS");

            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "PERSONAL_SETTING");

            migrationBuilder.DropTable(
                name: "REGISTRATION_FORM");

            migrationBuilder.DropTable(
                name: "REGISTRATION_FORM_QUESTION");

            migrationBuilder.DropTable(
                name: "REGISTRATION_FORM_QUESTION_OPTION");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "SYS_CODE_DTL");

            migrationBuilder.DropTable(
                name: "SYS_CODE_MST");

            migrationBuilder.DropTable(
                name: "TAG_LIST");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "USER_APPENDIX");

            migrationBuilder.DropTable(
                name: "USER_NOTIFY");
        }
    }
}
