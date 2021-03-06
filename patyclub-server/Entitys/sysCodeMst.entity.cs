using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_MST")]
  public class SysCodeMst
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //參數類別ID
    public int id { get; set; }

    [Column("name")] //參數類別
    public string name { get; set; }

    [Column("remark")] //備註
    public string remark { get; set; }  
    
  }
}