using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_PERSONNEL")]
  public class EventPersonnel
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventId")] //活動ID
    public int eventId { get; set; }

    [Column("permission")] //權限類別
    public string permission { get; set; }

    [Column("status")] //人員狀態
    public string status { get; set; }
  }

  public class EventPersonnelService
  {
    public DBContext _context;

    public EventPersonnelService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventPersonnel> GetEventPersonnels() {
      return _context.eventPersonnel.ToList();
    }
  }
}