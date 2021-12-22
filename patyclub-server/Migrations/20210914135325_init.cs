using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace patyclub_server.Migrations
{
    public partial class init : Migration
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
                name: "EVENT_APPENDIX",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    appendixPath = table.Column<int>(type: "integer", nullable: false)
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
                    parentId = table.Column<int>(type: "integer", nullable: false)
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
                    status = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<string>(type: "text", nullable: true),
                    eventStDate = table.Column<string>(type: "text", nullable: true),
                    eventEdDate = table.Column<string>(type: "text", nullable: true),
                    eventCreateDate = table.Column<string>(type: "text", nullable: true),
                    examinationPassedDate = table.Column<string>(type: "text", nullable: true),
                    eventIntroduction = table.Column<string>(type: "text", nullable: true),
                    eventDetail = table.Column<string>(type: "text", nullable: true),
                    eventAttantion = table.Column<string>(type: "text", nullable: true),
                    eventPrecaution = table.Column<string>(type: "text", nullable: true),
                    tag = table.Column<string>(type: "text", nullable: true)
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
                name: "EVENT_VIEW_LOG",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    eventMstId = table.Column<int>(type: "integer", nullable: false),
                    viewSeq = table.Column<int>(type: "integer", nullable: false),
                    viewDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_VIEW_LOG", x => new { x.userAccount, x.eventMstId });
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
                    id = table.Column<int>(type: "integer", nullable: false),
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    sysCodeMstId = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_CODE_DTL", x => new { x.sysCodeMstId, x.id });
                });

            migrationBuilder.CreateTable(
                name: "SYS_CODE_MST",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_CODE_MST", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    photoStickerPath = table.Column<string>(type: "text", nullable: true),
                    accountStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.account);
                });

            migrationBuilder.CreateTable(
                name: "USER_APPENDIX",
                columns: table => new
                {
                    userAccount = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_NOTIFY", x => new { x.userAccount, x.id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACHIEVEMENT");

            migrationBuilder.DropTable(
                name: "AUTO_COMPLETE_LIST");

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
                name: "EVENT_VIEW_LOG");

            migrationBuilder.DropTable(
                name: "MAPPING_PERMISSION_ROLE");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_ACHIEVEMENT");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_PERSONAL_SETTING");

            migrationBuilder.DropTable(
                name: "MAPPING_USER_ROLE");

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
                name: "User");

            migrationBuilder.DropTable(
                name: "USER_APPENDIX");

            migrationBuilder.DropTable(
                name: "USER_NOTIFY");
        }
    }
}
