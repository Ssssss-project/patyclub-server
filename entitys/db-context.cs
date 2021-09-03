using Microsoft.EntityFrameworkCore;
namespace patyclub_server.Entities
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }

        public DbSet<User> user { get; set; }
    }
}