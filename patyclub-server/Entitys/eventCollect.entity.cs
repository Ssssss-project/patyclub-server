using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_COLLECT")]
  public class EventCollect
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventMstId")] //活動ID
    public int eventMstId { get; set; }
  }
}