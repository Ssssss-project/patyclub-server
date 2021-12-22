using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("NEWS")]
  public class News
  {
    [Column("id")] //TAG ID
    public int id { get; set; }

    [Column("title")] //抬頭
    public string title { get; set; }

    [Column("context")] //內文
    public string context { get; set; }

    [Column("tag")] //標籤
    public string tag { get; set; }

    [Column("status")] //狀態
    public string status { get; set; }

    [Column("createdDate")] //創建時間
    public string createdDate { get; set; }

    [Column("lastUpdateDate")] //更新時間
    public string lastUpdateDate { get; set; }
  }
}