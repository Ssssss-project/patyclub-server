using Microsoft.EntityFrameworkCore;
namespace patyclub_server.Entities
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }

        public DbSet<Achievement> achievement { get; set; }
        public DbSet<AutoCompleteList> autoCompleteList { get; set; }
        public DbSet<EventMst> eventMst { get; set; }
        public DbSet<EventAppendix> eventAppendix { get; set; }
        public DbSet<EventCategory> eventCategory { get; set; }
        public DbSet<EventCollect> eventCollect { get; set; }
        public DbSet<EventPersonnel> eventPersonnel { get; set; }
        public DbSet<EventViewLog> eventViewLog { get; set; }
        public DbSet<MappingPermissionRole> mappingPermissionRole { get; set; }
        public DbSet<MappingUserAchievement> mappingUserAchievement { get; set; }
        public DbSet<MappingUserPersonalSetting> mappingUserPersonalSetting { get; set; }
        public DbSet<MappingUserRole> mappingUserRole { get; set; }
        public DbSet<Permission> permission { get; set; }
        public DbSet<PersonalSetting> personalSetting { get; set; }
        public DbSet<RegistrationForm> registrationForm { get; set; }
        public DbSet<RegistrationFormQuestion> registrationFormQuestion { get; set; }
        public DbSet<RegistrationFormQuestionOption> registrationFormQuestionOption { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<SysCodeDtl> sysCodeDtl { get; set; }
        public DbSet<SysCodeMst> sysCodeMst { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserAppendix> userAppendix { get; set; }
        public DbSet<UserNotify> userNotify { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCollect>()
                .HasKey(table => new {table.userAccount, table.eventMstId});
            modelBuilder.Entity<EventPersonnel>()
                .HasKey(table => new {table.userAccount, table.eventMstId});
            modelBuilder.Entity<EventViewLog>()
                .HasKey(table => new {table.userAccount, table.eventMstId});
            modelBuilder.Entity<MappingPermissionRole>()
                .HasKey(table => new {table.permissionId, table.roleId});
            modelBuilder.Entity<MappingUserAchievement>()
                .HasKey(table => new {table.userAccount, table.achievementId});
            modelBuilder.Entity<MappingUserPersonalSetting>()
                .HasKey(table => new {table.userAccount, table.personalSettingId});
            modelBuilder.Entity<MappingUserRole>()
                .HasKey(table => new {table.userAccount, table.roleId});
            modelBuilder.Entity<RegistrationForm>()
                .HasKey(table => new {table.userAccount, table.eventMstId, table.questionId});
            modelBuilder.Entity<RegistrationFormQuestionOption>()
                .HasKey(table => new {table.questionId, table.id});
            modelBuilder.Entity<SysCodeDtl>()
                .HasKey(table => new {table.sysCodeMstId, table.id});
            modelBuilder.Entity<User>()
                .HasKey(table => new {table.account});
            modelBuilder.Entity<UserAppendix>()
                .HasKey(table => new {table.userAccount, table.id});
            modelBuilder.Entity<UserNotify>()
                .HasKey(table => new {table.userAccount, table.id});

            

            modelBuilder.Entity<Achievement>()
                .HasData(
                    new Achievement {id = 1, describe = "連續登入10天", goal = 10}
                );
            modelBuilder.Entity<AutoCompleteList>()
                .HasData(
                    new AutoCompleteList {id = 1, content = "patyclub", category = "常用搜尋詞"}
                );
            modelBuilder.Entity<EventMst>()
                .HasData(
                    new EventMst {id = 1, categoryId = 3, eventTitle = "爬爬爬爬爬山趣", status = "T", cost = "1000", tag = "H"},
                    new EventMst {id = 2, categoryId = 3, eventTitle = "颱風天要幹嘛? 當然是去泛舟R!", status = "T", cost = "1000", tag = "S"},
                    new EventMst {id = 3, categoryId = 2, eventTitle = "SideProject Coding...", status = "T", cost = "1000", tag = "S"},
                    new EventMst {id = 4, categoryId = 1, eventTitle = "一日雙塔，騎起來~", status = "T", cost = "1000", tag = "S"},
                    new EventMst {id = 5, categoryId = 4, eventTitle = "JustDance跳跳跳!", status = "T", cost = "1000", tag = "H"},
                    new EventMst {id = 6, categoryId = 4, eventTitle = "不想想活動名-A1", status = "T", cost = "1000", tag = ""},
                    new EventMst {id = 7, categoryId = 4, eventTitle = "不想想活動名-A2", status = "T", cost = "1000", tag = ""},
                    new EventMst {id = 8, categoryId = 4, eventTitle = "不想想活動名-A3", status = "T", cost = "1000", tag = "S"},
                    new EventMst {id = 9, categoryId = 4, eventTitle = "不想想活動名-A4", status = "T", cost = "1000", tag = ""},
                    new EventMst {id = 10, categoryId = 4, eventTitle = "不想想活動名-A5", status = "T", cost = "1000", tag = ""},
                    new EventMst {id = 11, categoryId = 4, eventTitle = "不想想活動名-A6", status = "T", cost = "1000", tag = "S"},
                    new EventMst {id = 12, categoryId = 4, eventTitle = "不想想活動名-A7", status = "T", cost = "1000", tag = ""}
                );
            // modelBuilder.Entity<EventAppendix>()
            //     .HasData(
            //         new EventAppendix {}
            //     );
            modelBuilder.Entity<EventCategory>()
                .HasData(
                    new EventCategory {id = 1, categoryName = "測試活動A", parentId = 0, enable = "Y"},
                    new EventCategory {id = 2, categoryName = "測試活動B", parentId = 0, enable = "Y"},
                    new EventCategory {id = 3, categoryName = "測試活動A-1", parentId = 1, enable = "Y"},
                    new EventCategory {id = 4, categoryName = "測試活動A-2", parentId = 1, enable = "Y"},
                    new EventCategory {id = 5, categoryName = "測試活動A-3", parentId = 1, enable = "N"}
                );
            // modelBuilder.Entity<EventCollect>()
            //     .HasData(
            //         new EventCollect {}
            //     );
            // modelBuilder.Entity<EventPersonnel>()
            //     .HasData(
            //         new EventPersonnel {}
            //     );
            // modelBuilder.Entity<EventViewLog>()
            //     .HasData(
            //         new EventViewLog {}
            //     );
            // modelBuilder.Entity<MappingPermissionRole>()
            //     .HasData(
            //         new MappingPermissionRole {}
            //     );
            // modelBuilder.Entity<MappingUserAchievement>()
            //     .HasData(
            //         new MappingUserAchievement {}
            //     );
            // modelBuilder.Entity<MappingUserPersonalSetting>()
            //     .HasData(
            //         new MappingUserPersonalSetting {}
            //     );
            // modelBuilder.Entity<MappingUserRole>()
            //     .HasData(
            //         new MappingUserRole {}
            //     );
            // modelBuilder.Entity<Permission>()
            //     .HasData(
            //         new Permission {}
            //     );
            // modelBuilder.Entity<PersonalSetting>()
            //     .HasData(
            //         new PersonalSetting {}
            //     );
            // modelBuilder.Entity<RegistrationForm>()
            //     .HasData(
            //         new RegistrationForm {}
            //     );
            // modelBuilder.Entity<RegistrationFormQuestion>()
            //     .HasData(
            //         new RegistrationFormQuestion {}
            //     );
            // modelBuilder.Entity<RegistrationFormQuestionOption>()
            //     .HasData(
            //         new RegistrationFormQuestionOption {}
            //     );
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role {id = 1, name = "系統管理員"},
                    new Role {id = 2, name = "一般使用者"}
                );
            modelBuilder.Entity<SysCodeDtl>()
                .HasData(
                    new SysCodeDtl {id = 1, sysCodeMstId = 1, codeName = "H", codeDesc = "熱門活動"},
                    new SysCodeDtl {id = 2, sysCodeMstId = 1, codeName = "S", codeDesc = "精選活動"},
                    new SysCodeDtl {id = 3, sysCodeMstId = 2, codeName = "T", codeDesc = "暫存中"},
                    new SysCodeDtl {id = 4, sysCodeMstId = 2, codeName = "C", codeDesc = "已取消"},
                    new SysCodeDtl {id = 5, sysCodeMstId = 2, codeName = "D", codeDesc = "已刪除"}
                );
            modelBuilder.Entity<SysCodeMst>()
                .HasData(
                    new SysCodeMst {id = 1, name = "TAG", remark = "活動標記代碼"},
                    new SysCodeMst {id = 2, name = "eventStatus", remark = "活動狀態代碼"}
                );
            modelBuilder.Entity<User>()
                .HasData(
                    new User {account = "adda", password = "adda", name = "阿達", accountStatus = "Active"},
                    new User {account = "admin", password = "admin", name = "阿管", accountStatus = "Active"}
                );
            // modelBuilder.Entity<UserAppendix>()
            //     .HasData(
            //         new UserAppendix {}
            //     );
            // modelBuilder.Entity<UserNotify>()
            //     .HasData(
            //         new UserNotify {}
            //     );

        }
        #endregion

    }
}