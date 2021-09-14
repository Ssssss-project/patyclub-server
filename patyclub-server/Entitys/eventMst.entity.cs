using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_MST")]
  public class EventMst
  {
    [Column("id")] // 活動ID
    public int id { get; set; }

    [Column("categoryId")] //類別ID
    public int categoryId { get; set; }

    [Column("status")] //活動狀態
    public string status { get; set; }

    [Column("cost")] //活動費用
    public string cost { get; set; }

    [Column("eventStDate")] //活動開始日期
    public string eventStDate { get; set; }

    [Column("eventEdDate")] //活動結束日期
    public string eventEdDate { get; set; }

    [Column("eventCreateDate")] //活動創建日期
    public string eventCreateDate { get; set; }

    [Column("examinationPassedDate")] //審核通過日期
    public string examinationPassedDate { get; set; }

    [Column("eventIntroduction")] //活動簡介
    public string eventIntroduction { get; set; }

    [Column("eventDetail")] //活動細項
    public string eventDetail { get; set; }

    [Column("eventAttantion")] //活動細項
    public string eventAttantion { get; set; }

    [Column("eventPrecaution")] //活動注意事項
    public string eventPrecaution { get; set; }

    [Column("tag")] //活動標籤
    public string tag { get; set; }
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