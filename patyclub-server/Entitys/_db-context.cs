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
        public DbSet<MappingEventTag> mappingEventTag { get; set; }
        public DbSet<MappingPermissionRole> mappingPermissionRole { get; set; }
        public DbSet<MappingUserAchievement> mappingUserAchievement { get; set; }
        public DbSet<MappingUserPersonalSetting> mappingUserPersonalSetting { get; set; }
        public DbSet<MappingUserRole> mappingUserRole { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Permission> permission { get; set; }
        public DbSet<PersonalSetting> personalSetting { get; set; }
        public DbSet<RegistrationForm> registrationForm { get; set; }
        public DbSet<RegistrationFormQuestion> registrationFormQuestion { get; set; }
        public DbSet<RegistrationFormQuestionOption> registrationFormQuestionOption { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<SysCodeDtl> sysCodeDtl { get; set; }
        public DbSet<SysCodeMst> sysCodeMst { get; set; }
        public DbSet<TagList> tagList { get; set; }
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
            modelBuilder.Entity<MappingEventTag>()
                .HasKey(table => new {table.eventMstId, table.tagId});
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

new EventMst {id = 1, categoryId = 3, status = "T", cost = "1000", eventStDate = "2021/12/31", eventEdDate = "2021/12/31", eventCreateDate = "2021/12/05", examinationPassedDate = "2021/12/10", eventIntroduction = @"號稱台中最美的中級山-鳶嘴山，是台中登山旅遊的熱門景點，位在台中東勢，海拔2180公尺，險峻的峭壁危崖吸引許多喜歡冒險的登山者挑戰。

對於初次挑戰者困難度稍高，建議有登山經驗的帶領會比較安全一點，登頂後的美麗風景讓人覺得一切真的都值得，有機會的話真的要來造訪一次", eventDetail = @"日期：2021/03/20（六）
天氣：晴☀️
人數：阿寶、陳先生、毛毛，3人皆常爬山
難度：中
距離：全程2.1公里（27k上、27.3k下）
時程：3小時45分
07:45 27k登山口
08:00 鳶嘴山/橫嶺山岔口
08:25 二葉松涼亭
09:10 鳶嘴山
09:30 開始下山
10:30 結束拉繩陡下
10:45 稍來山/大雪山林道岔口
11:30 27.3k登山口

喝水800ml", eventAttantion = @"【行前準備】

1. 1500～2000cc 水

2. 手套 （看個人非必要）有幾處需拉繩

3. 穿登山鞋 或 較深紋路的鞋子

4. 兩截式雨衣 （沒有的話就輕便雨衣）

5. 長褲 （有彈性較佳）

6. 身份證

7. 午餐（麵包 or 御飯糰 之類）

8. 帽子 （看個人非必要）

9. 禦寒衣物

10.小型後背包 

11.一套乾淨衣服放車上回程如果有濕可換 

12.衛生紙

13.毛巾 （看個人非必要）", tag = "H", eventTitle = "爬爬爬爬爬山趣"},
new EventMst {id = 2, categoryId = 3, status = "T", cost = "1000", eventStDate = "2021/12/05", eventEdDate = "2021/12/05", eventCreateDate = "2021/12/05", examinationPassedDate = "2021/12/05", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "S", eventTitle = "颱風天要幹嘛? 當然是去泛舟R!"},
new EventMst {id = 3, categoryId = 2, status = "T", cost = "1000", eventStDate = "2021/12/15", eventEdDate = "2021/12/17", eventCreateDate = "2021/12/01", examinationPassedDate = "2021/12/10", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "S", eventTitle = "SideProject Coding..."},
new EventMst {id = 4, categoryId = 1, status = "T", cost = "1000", eventStDate = "2021/12/18", eventEdDate = "2021/12/20", eventCreateDate = "2021/12/05", examinationPassedDate = "", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "S", eventTitle = "一日雙塔，騎起來~"},
new EventMst {id = 5, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/20", eventEdDate = "2021/12/20", eventCreateDate = "2021/12/01", examinationPassedDate = "2021/12/10", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "H", eventTitle = "JustDance跳跳跳!"},
new EventMst {id = 6, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/15", eventEdDate = "2021/12/16", eventCreateDate = "2021/12/02", examinationPassedDate = "", eventIntroduction = @"銅牌一日上白金", eventDetail = @"今天晚上五點開打
打到白金為止", eventAttantion = @"雷包勿來", tag = "", eventTitle = "APEX 爬分"},
new EventMst {id = 7, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/25", eventEdDate = "2021/12/26", eventCreateDate = "2021/12/01", examinationPassedDate = "2021/12/20", eventIntroduction = @"如題", eventDetail = @"打到大家都累為止", eventAttantion = @"for fun", tag = "", eventTitle = "LOL NG隨便打"},
new EventMst {id = 8, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/2", eventEdDate = "2021/12/5", eventCreateDate = "2021/12/05", examinationPassedDate = "", eventIntroduction = @"阿里山鄉位於臺灣嘉義縣東部，北鄰南投縣竹山鎮，東鄰南投縣信義鄉、高雄市桃源區，西鄰梅山鄉、竹崎鄉、番路鄉，南接大埔鄉與高雄市那瑪夏區，是嘉義縣面積最大、人口密度最低的鄉鎮，其面積約佔全縣的1/5，也是嘉義縣唯一的山地鄉。", eventDetail = @"記得攜帶個人所需物品
天冷注意保暖", eventAttantion = @"要帶夠錢錢
要帶水
要帶健保卡", tag = "S", eventTitle = "阿里山郊遊趣"},
new EventMst {id = 9, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/3", eventEdDate = "2021/12/8", eventCreateDate = "2021/12/01", examinationPassedDate = "", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "", eventTitle = "不想想活動名-A4"},
new EventMst {id = 10, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/5", eventEdDate = "2021/12/5", eventCreateDate = "2021/12/02", examinationPassedDate = "2021/12/2", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "", eventTitle = "不想想活動名-A5"},
new EventMst {id = 11, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/9", eventEdDate = "2021/12/9", eventCreateDate = "2021/12/01", examinationPassedDate = "", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "S", eventTitle = "不想想活動名-A6"},
new EventMst {id = 12, categoryId = 4, status = "T", cost = "1000", eventStDate = "2021/12/8", eventEdDate = "2021/12/8", eventCreateDate = "2021/12/02", examinationPassedDate = "", eventIntroduction = @"", eventDetail = @"", eventAttantion = @"", tag = "", eventTitle = "不想想活動名-A7"}

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
                    new User {account = "admin", password = "admin", name = "阿管", email = "patyclub9453@gmail.com", accountStatus = "Active"},
                    new User {account = "yiyuan", password = "yiyuan", name = "阿摳", email = "charles01270@gmail.com", accountStatus = "Active"},
                    new User {account = "pang", password = "pang", name = "阿彭", email = "cxz0917001997@gmail.com", accountStatus = "Active"}
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