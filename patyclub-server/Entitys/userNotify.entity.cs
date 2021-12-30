using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("USER_NOTIFY")]
  public class UserNotify
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //通知ID
    public int id { get; set; }

    [Column("category")] //通知類別
    public string category { get; set; }

    [Column("content")] //通知內容
    public string content { get; set; }

    [Column("status")] //通知狀態
    public string status { get; set; }
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