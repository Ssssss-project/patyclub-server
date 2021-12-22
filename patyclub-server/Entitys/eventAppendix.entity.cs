using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_APPENDIX")]
  public class EventAppendix
  {
    [Column("id")] //附件ID
    public int id { get; set; }

    [Column("eventMstId")] //活動ID
    public int eventMstId { get; set; }

    [Column("category")] //附件類別
    public string category { get; set; }

    [Column("appendixPath")] //附件路徑
    public string appendixPath { get; set; }

  }

  public class EventAppendixService
  {
    public DBContext _context;

    public EventAppendixService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EventAppendix> GetEventAppendixs() {
      return _context.eventAppendix.ToList();
    }
  }
}