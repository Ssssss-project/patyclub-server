﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using patyclub_server.Entities;

namespace patyclub_server.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210914143709_add test data")]
    partial class addtestdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("parentId")
                        .HasColumnType("integer")
                        .HasColumnName("parentId");

                    b.HasKey("id");

                    b.ToTable("EVENT_CATEGORY");
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

                    b.Property<string>("content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("sysCodeMstId", "id");

                    b.ToTable("SYS_CODE_DTL");
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
                            name = "阿管",
                            password = "admin"
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
