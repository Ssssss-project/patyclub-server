using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("AUTO_COMPLETE_LIST")]
  public class AutoCompleteList
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //ID
    public int id { get; set; }

    [Column("content")] //內容
    public string content { get; set; }

    [Column("category")] //類別
    public string category { get; set; }

  }
}