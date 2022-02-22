using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_PERSONNEL")]
  public class EventPersonnel
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventMstId")] //活動ID
    public int eventMstId { get; set; }

    [Column("permission")] //權限類別
    public string permission { get; set; }

    [Column("status")] //人員狀態
    public string status { get; set; }
  }
}