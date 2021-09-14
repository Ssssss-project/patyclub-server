using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("USER_NOTIFY")]
  public class UserNotify
  {
    [Column("id")]
    public int id { get; set; }

    [Column("name")]
    public string name { get; set; }

    [Column("phone")]
    public string phone { get; set; }

    [Column("status")]
    public string status { get; set; }

    [Column("remark")]
    public string remark { get; set; }
  }

  public class UserNotifyService
  {
    public DBContext _context;

    public UserNotifyService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<UserNotify> GetUserNotifys() {
      return _context.userNotify.ToList();
    }
  }
}