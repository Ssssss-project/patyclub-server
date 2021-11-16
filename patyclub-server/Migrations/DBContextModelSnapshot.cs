﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using patyclub_server.Entities;

namespace patyclub_server.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("patyclub_server.Entities.Achievement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("describe")
                        .HasColumnType("text")
                        .HasColumnName("describe");

                    b.Property<int>("goal")
                        .HasColumnType("integer")
                        .HasColumnName("goal");

                    b.HasKey("id");

                    b.ToTable("ACHIEVEMENT");

                    b.HasData(
                        new
                        {
                            id = 1,
                            describe = "連續登入10天",
                            goal = 10
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.AutoCompleteList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("id");

                    b.ToTable("AUTO_COMPLETE_LIST");

                    b.HasData(
                        new
                        {
                            id = 1,
                            category = "常用搜尋詞",
                            content = "patyclub"
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.EventAppendix", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("appendixPath")
                        .HasColumnType("integer")
                        .HasColumnName("appendixPath");

                    b.Property<int>("category")
                        .HasColumnType("integer")
                        .HasColumnName("category");

                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.HasKey("id");

                    b.ToTable("EVENT_APPENDIX");
                });

            modelBuilder.Entity("patyclub_server.Entities.EventCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("text")
                        .HasColumnName("categoryName");

                    b.Property<string>("enable")
                        .HasColumnType("text")
                        .HasColumnName("enable");

                    b.Property<int>("parentId")
                        .HasColumnType("integer")
                        .HasColumnName("parentId");

                    b.HasKey("id");

                    b.ToTable("EVENT_CATEGORY");

                    b.HasData(
                        new
                        {
                            id = 1,
                            categoryName = "測試活動A",
                            enable = "Y",
                            parentId = 0
                        },
                        new
                        {
                            id = 2,
                            categoryName = "測試活動B",
                            enable = "Y",
                            parentId = 0
                        },
                        new
                        {
                            id = 3,
                            categoryName = "測試活動A-1",
                            enable = "Y",
                            parentId = 1
                        },
                        new
                        {
                            id = 4,
                            categoryName = "測試活動A-2",
                            enable = "Y",
                            parentId = 1
                        },
                        new
                        {
                            id = 5,
                            categoryName = "測試活動A-3",
                            enable = "N",
                            parentId = 1
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.EventCollect", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.HasKey("userAccount", "eventMstId");

                    b.ToTable("EVENT_COLLECT");
                });

            modelBuilder.Entity("patyclub_server.Entities.EventMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("categoryId")
                        .HasColumnType("integer")
                        .HasColumnName("categoryId");

                    b.Property<string>("cost")
                        .HasColumnType("text")
                        .HasColumnName("cost");

                    b.Property<string>("eventAttantion")
                        .HasColumnType("text")
                        .HasColumnName("eventAttantion");

                    b.Property<string>("eventCreateDate")
                        .HasColumnType("text")
                        .HasColumnName("eventCreateDate");

                    b.Property<string>("eventDetail")
                        .HasColumnType("text")
                        .HasColumnName("eventDetail");

                    b.Property<string>("eventEdDate")
                        .HasColumnType("text")
                        .HasColumnName("eventEdDate");

                    b.Property<string>("eventIntroduction")
                        .HasColumnType("text")
                        .HasColumnName("eventIntroduction");

                    b.Property<string>("eventPrecaution")
                        .HasColumnType("text")
                        .HasColumnName("eventPrecaution");

                    b.Property<string>("eventStDate")
                        .HasColumnType("text")
                        .HasColumnName("eventStDate");

                    b.Property<string>("eventTitle")
                        .HasColumnType("text")
                        .HasColumnName("eventTitle");

                    b.Property<string>("examinationPassedDate")
                        .HasColumnType("text")
                        .HasColumnName("examinationPassedDate");

                    b.Property<string>("status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("tag")
                        .HasColumnType("text")
                        .HasColumnName("tag");

                    b.HasKey("id");

                    b.ToTable("EVENT_MST");

                    b.HasData(
                        new
                        {
                            id = 1,
                            categoryId = 3,
                            cost = "1000",
                            eventTitle = "爬爬爬爬爬山趣",
                            status = "T",
                            tag = "H"
                        },
                        new
                        {
                            id = 2,
                            categoryId = 3,
                            cost = "1000",
                            eventTitle = "颱風天要幹嘛? 當然是去泛舟R!",
                            status = "T",
                            tag = "S"
                        },
                        new
                        {
                            id = 3,
                            categoryId = 2,
                            cost = "1000",
                            eventTitle = "SideProject Coding...",
                            status = "T",
                            tag = "S"
                        },
                        new
                        {
                            id = 4,
                            categoryId = 1,
                            cost = "1000",
                            eventTitle = "一日雙塔，騎起來~",
                            status = "T",
                            tag = "S"
                        },
                        new
                        {
                            id = 5,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "JustDance跳跳跳!",
                            status = "T",
                            tag = "H"
                        },
                        new
                        {
                            id = 6,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A1",
                            status = "T",
                            tag = ""
                        },
                        new
                        {
                            id = 7,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A2",
                            status = "T",
                            tag = ""
                        },
                        new
                        {
                            id = 8,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A3",
                            status = "T",
                            tag = "S"
                        },
                        new
                        {
                            id = 9,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A4",
                            status = "T",
                            tag = ""
                        },
                        new
                        {
                            id = 10,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A5",
                            status = "T",
                            tag = ""
                        },
                        new
                        {
                            id = 11,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A6",
                            status = "T",
                            tag = "S"
                        },
                        new
                        {
                            id = 12,
                            categoryId = 4,
                            cost = "1000",
                            eventTitle = "不想想活動名-A7",
                            status = "T",
                            tag = ""
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.EventPersonnel", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.Property<string>("permission")
                        .HasColumnType("text")
                        .HasColumnName("permission");

                    b.Property<string>("status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("userAccount", "eventMstId");

                    b.ToTable("EVENT_PERSONNEL");
                });

            modelBuilder.Entity("patyclub_server.Entities.EventViewLog", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.Property<string>("viewDate")
                        .HasColumnType("text")
                        .HasColumnName("viewDate");

                    b.Property<int>("viewSeq")
                        .HasColumnType("integer")
                        .HasColumnName("viewSeq");

                    b.HasKey("userAccount", "eventMstId");

                    b.ToTable("EVENT_VIEW_LOG");
                });

            modelBuilder.Entity("patyclub_server.Entities.MappingEventTag", b =>
                {
                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.Property<int>("tagId")
                        .HasColumnType("integer")
                        .HasColumnName("tagId");

                    b.HasKey("eventMstId", "tagId");

                    b.ToTable("MAPPING_EVENT_TAG");
                });

            modelBuilder.Entity("patyclub_server.Entities.MappingPermissionRole", b =>
                {
                    b.Property<int>("permissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permissionId");

                    b.Property<int>("roleId")
                        .HasColumnType("integer")
                        .HasColumnName("roleId");

                    b.HasKey("permissionId", "roleId");

                    b.ToTable("MAPPING_PERMISSION_ROLE");
                });

            modelBuilder.Entity("patyclub_server.Entities.MappingUserAchievement", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("achievementId")
                        .HasColumnType("integer")
                        .HasColumnName("achievementId");

                    b.Property<string>("currentProgress")
                        .HasColumnType("text")
                        .HasColumnName("currentProgress");

                    b.HasKey("userAccount", "achievementId");

                    b.ToTable("MAPPING_USER_ACHIEVEMENT");
                });

            modelBuilder.Entity("patyclub_server.Entities.MappingUserPersonalSetting", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("personalSettingId")
                        .HasColumnType("integer")
                        .HasColumnName("personalSettingId");

                    b.Property<string>("settingValue")
                        .HasColumnType("text")
                        .HasColumnName("settingValue");

                    b.HasKey("userAccount", "personalSettingId");

                    b.ToTable("MAPPING_USER_PERSONAL_SETTING");
                });

            modelBuilder.Entity("patyclub_server.Entities.MappingUserRole", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("roleId")
                        .HasColumnType("integer")
                        .HasColumnName("roleId");

                    b.HasKey("userAccount", "roleId");

                    b.ToTable("MAPPING_USER_ROLE");
                });

            modelBuilder.Entity("patyclub_server.Entities.News", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("context")
                        .HasColumnType("text")
                        .HasColumnName("context");

                    b.Property<string>("createdDate")
                        .HasColumnType("text")
                        .HasColumnName("createdDate");

                    b.Property<string>("lastUpdateDate")
                        .HasColumnType("text")
                        .HasColumnName("lastUpdateDate");

                    b.Property<string>("status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("tag")
                        .HasColumnType("text")
                        .HasColumnName("tag");

                    b.Property<string>("title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("id");

                    b.ToTable("NEWS");
                });

            modelBuilder.Entity("patyclub_server.Entities.Permission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("actionCategory")
                        .HasColumnType("text")
                        .HasColumnName("actionCategory");

                    b.Property<string>("functionName")
                        .HasColumnType("text")
                        .HasColumnName("functionName");

                    b.HasKey("id");

                    b.ToTable("PERMISSION");
                });

            modelBuilder.Entity("patyclub_server.Entities.PersonalSetting", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.HasKey("id");

                    b.ToTable("PERSONAL_SETTING");
                });

            modelBuilder.Entity("patyclub_server.Entities.RegistrationForm", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("eventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("eventMstId");

                    b.Property<int>("questionId")
                        .HasColumnType("integer")
                        .HasColumnName("questionId");

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("userAccount", "eventMstId", "questionId");

                    b.ToTable("REGISTRATION_FORM");
                });

            modelBuilder.Entity("patyclub_server.Entities.RegistrationFormQuestion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EventMstId")
                        .HasColumnType("integer")
                        .HasColumnName("EventMstId");

                    b.Property<string>("category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("id");

                    b.ToTable("REGISTRATION_FORM_QUESTION");
                });

            modelBuilder.Entity("patyclub_server.Entities.RegistrationFormQuestionOption", b =>
                {
                    b.Property<int>("questionId")
                        .HasColumnType("integer")
                        .HasColumnName("questionId");

                    b.Property<int>("id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("questionId", "id");

                    b.ToTable("REGISTRATION_FORM_QUESTION_OPTION");
                });

            modelBuilder.Entity("patyclub_server.Entities.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("id");

                    b.ToTable("ROLE");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "系統管理員"
                        },
                        new
                        {
                            id = 2,
                            name = "一般使用者"
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.SysCodeDtl", b =>
                {
                    b.Property<int>("sysCodeMstId")
                        .HasColumnType("integer")
                        .HasColumnName("sysCodeMstId");

                    b.Property<int>("id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("codeDesc")
                        .HasColumnType("text")
                        .HasColumnName("codeDesc");

                    b.Property<string>("codeName")
                        .HasColumnType("text")
                        .HasColumnName("codeName");

                    b.HasKey("sysCodeMstId", "id");

                    b.ToTable("SYS_CODE_DTL");

                    b.HasData(
                        new
                        {
                            sysCodeMstId = 1,
                            id = 1,
                            codeDesc = "熱門活動",
                            codeName = "H"
                        },
                        new
                        {
                            sysCodeMstId = 1,
                            id = 2,
                            codeDesc = "精選活動",
                            codeName = "S"
                        },
                        new
                        {
                            sysCodeMstId = 2,
                            id = 3,
                            codeDesc = "暫存中",
                            codeName = "T"
                        },
                        new
                        {
                            sysCodeMstId = 2,
                            id = 4,
                            codeDesc = "已取消",
                            codeName = "C"
                        },
                        new
                        {
                            sysCodeMstId = 2,
                            id = 5,
                            codeDesc = "已刪除",
                            codeName = "D"
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.SysCodeMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("remark")
                        .HasColumnType("text")
                        .HasColumnName("remark");

                    b.HasKey("id");

                    b.ToTable("SYS_CODE_MST");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "TAG",
                            remark = "活動標記代碼"
                        },
                        new
                        {
                            id = 2,
                            name = "eventStatus",
                            remark = "活動狀態代碼"
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.TagList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("tagName")
                        .HasColumnType("text")
                        .HasColumnName("tagName");

                    b.HasKey("id");

                    b.ToTable("TAG_LIST");
                });

            modelBuilder.Entity("patyclub_server.Entities.User", b =>
                {
                    b.Property<string>("account")
                        .HasColumnType("text")
                        .HasColumnName("account");

                    b.Property<string>("accountStatus")
                        .HasColumnType("text")
                        .HasColumnName("accountStatus");

                    b.Property<string>("activeState")
                        .HasColumnType("text")
                        .HasColumnName("activeState");

                    b.Property<string>("birthday")
                        .HasColumnType("text")
                        .HasColumnName("birthday");

                    b.Property<string>("city")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("country")
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("emotionalState")
                        .HasColumnType("text")
                        .HasColumnName("emotionalState");

                    b.Property<string>("forgetPwdToken")
                        .HasColumnType("text")
                        .HasColumnName("forgetPwdToken");

                    b.Property<string>("forgetPwdTokenCreatedDate")
                        .HasColumnType("text")
                        .HasColumnName("forgetPwdTokenCreatedDate");

                    b.Property<string>("introduction")
                        .HasColumnType("text")
                        .HasColumnName("introduction");

                    b.Property<string>("name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("nickName")
                        .HasColumnType("text")
                        .HasColumnName("nickName");

                    b.Property<string>("password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("photoStickerPath")
                        .HasColumnType("text")
                        .HasColumnName("photoStickerPath");

                    b.Property<string>("sex")
                        .HasColumnType("text")
                        .HasColumnName("sex");

                    b.HasKey("account");

                    b.ToTable("USER");

                    b.HasData(
                        new
                        {
                            account = "adda",
                            accountStatus = "Active",
                            name = "阿達",
                            password = "adda"
                        },
                        new
                        {
                            account = "admin",
                            accountStatus = "Active",
                            email = "patyclub9453@gmail.com",
                            name = "阿管",
                            password = "admin"
                        },
                        new
                        {
                            account = "yiyuan",
                            accountStatus = "Active",
                            email = "charles01270@gmail.com",
                            name = "阿摳",
                            password = "yiyuan"
                        },
                        new
                        {
                            account = "pang",
                            accountStatus = "Active",
                            email = "cxz0917001997@gmail.com",
                            name = "阿彭",
                            password = "pang"
                        });
                });

            modelBuilder.Entity("patyclub_server.Entities.UserAppendix", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("appendixPath")
                        .HasColumnType("text")
                        .HasColumnName("appendixPath");

                    b.HasKey("userAccount", "id");

                    b.ToTable("USER_APPENDIX");
                });

            modelBuilder.Entity("patyclub_server.Entities.UserNotify", b =>
                {
                    b.Property<string>("userAccount")
                        .HasColumnType("text")
                        .HasColumnName("userAccount");

                    b.Property<int>("id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("userAccount", "id");

                    b.ToTable("USER_NOTIFY");
                });
#pragma warning restore 612, 618
        }
    }
}
