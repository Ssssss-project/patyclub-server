using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("CLIENT_LOG")]
  public class ClientLog
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int id {get; set;} 

    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("targetSeq")] //目標序列 "eventTouch": eventMstId, "pageTouch": pageId, "searchQuery": queryString
    public string targetSeq { get; set; }

    [Column("logCategory")] //LOG類別 "eventTouch", "pageTouch", "searchQuery"
    public string logCategory { get; set; }

    [Column("logDate")] //紀錄日期
    public string logDate { get; set; }
  }
}