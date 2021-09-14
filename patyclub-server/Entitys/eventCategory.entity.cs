using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_CATEGORY")]
  public class EventCategory
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

  public class EventCategoryService
  {
    public DBContext _context;

    public EventCategoryService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventCategory> GetEventCategorys() {
      return _context.eventCategory.ToList();
    }
  }
}