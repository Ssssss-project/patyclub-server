using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_CATEGORY")]
  public class EventCategory
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //類別ID
    public int id { get; set; }

    [Column("categoryName")] //類別名稱
    public string categoryName { get; set; }

    [Column("parentId")] //父類別ID
    public int parentId { get; set; }

    [Column("enable")] //是否啟用
    public string enable {get; set;}
  }
}