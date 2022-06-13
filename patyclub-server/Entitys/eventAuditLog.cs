using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_AUDIT_LOG")]
  public class EventAuditLog
  {
    [Column("eventId")] //活動ID
    public int eventId { get; set; }

    [Column("auditSeq")] //審查序號
    public int auditSeq { get; set; }

    [Column("auditTarget")] //審查目標
    public string auditTarget { get; set; }

    [Column("auditMessage")] //審查意見
    public string auditMessage { get; set; } 

    [Column("createdDate")] //創建時間
    public string createdDate { get; set; }
  }
}