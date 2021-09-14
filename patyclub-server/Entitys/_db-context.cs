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
            // modelBuilder.Entity<EventMst>()
            //     .HasData(
            //         new EventMst {}
            //     );
            // modelBuilder.Entity<EventAppendix>()
            //     .HasData(
            //         new EventAppendix {}
            //     );
            // modelBuilder.Entity<EventCategory>()
            //     .HasData(
            //         new EventCategory {}
            //     );
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
            // modelBuilder.Entity<SysCodeDtl>()
            //     .HasData(
            //         new SysCodeDtl {}
            //     );
            // modelBuilder.Entity<SysCodeMst>()
            //     .HasData(
            //         new SysCodeMst {}
            //     );
            modelBuilder.Entity<User>()
                .HasData(
                    // new User {account = "adda", password = "adda", name = "阿達", accountStatus = "Active"},
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