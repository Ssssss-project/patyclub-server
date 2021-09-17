using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_CATEGORY")]
  public class EventCategory
  {
    [Column("id")] //類別ID
    public int id { get; set; }

    [Column("categoryName")] //類別名稱
    public string categoryName { get; set; }

    [Column("parentId")] //父類別ID
    public int parentId { get; set; }
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