using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_VIEW_LOG")]
  public class EventViewLog
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