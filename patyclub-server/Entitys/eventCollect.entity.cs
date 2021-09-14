using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_COLLECT")]
  public class EventCollect
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventId")] //活動ID
    public int eventId { get; set; }
  }

  public class EventCollectService
  {
    public DBContext _context;

    public EventCollectService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventCollect> GetEventCollects() {
      return _context.eventCollect.ToList();
    }
  }
}