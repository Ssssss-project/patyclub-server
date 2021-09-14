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
        public DbSet<EvnetPersonnel> evnetPersonnel { get; set; }
        public DbSet<EventViewLog> eventViewLog { get; set; }
        public DbSet<MappingPermissionRole> mappingPermissionRole { get; set; }
        public DbSet<MappingUserAchievement> mappingUserAchievement { get; set; }
        public DbSet<MappingUserPersonalSetting> mappingUserPersonalSetting { get; set; }
        public DbSet<MappingUserRole> mappingUserRole { get; set; }
        public DbSet<Permission> permission { get; set; }
        public DbSet<PersonalSetting> personalSetting { get; set; }
        public DbSet<RegistrationForm> registrationForm { get; set; }
        public DbSet<RegistrationFormQuestion> registrationFormQuestion { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<SysCodeDtl> sysCodeDtl { get; set; }
        public DbSet<SysCodeMst> sysCodeMst { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserAppendix> userAppendix { get; set; }
        public DbSet<UserNotify> userNotify { get; set; }

    }
}