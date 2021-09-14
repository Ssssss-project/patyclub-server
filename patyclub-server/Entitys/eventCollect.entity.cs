using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_COLLECT")]
  public class EventCollect
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