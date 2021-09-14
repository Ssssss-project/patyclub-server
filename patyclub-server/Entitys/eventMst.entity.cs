using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_MST")]
  public class EventMst
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

  public class EventMstService
  {
    public DBContext _context;

    public EventMstService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventMst> GetEventMsts() {
      return _context.eventMst.ToList();
    }
  }
}