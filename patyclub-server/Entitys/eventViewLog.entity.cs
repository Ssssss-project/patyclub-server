using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_VIEW_LOG")]
  public class EventViewLog
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventId")] //活動ID
    public int eventId { get; set; }

    [Column("viewSeq")] //檢視序號
    public int viewSeq { get; set; }

    [Column("viewDate")] //檢視日期
    public string viewDate { get; set; }
  }

  public class EventViewLogService
  {
    public DBContext _context;

    public EventViewLogService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventViewLog> GetEventViewLogs() {
      return _context.eventViewLog.ToList();
    }
  }
}