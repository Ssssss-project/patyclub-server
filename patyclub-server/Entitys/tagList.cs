using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("TAG_LIST")]
  public class TagList
  {
    [Column("id")] //TAG ID
    public int id { get; set; }

    [Column("tagName")] //標籤名稱
    public string tagName { get; set; }

  }
}