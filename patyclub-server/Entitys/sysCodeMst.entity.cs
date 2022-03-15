using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_MST")]
  public class SysCodeMst
  {
    [Column("keyword")] //參數識別碼
    public string keyword { get; set; }

    [Column("name")] //參數類別
    public string name { get; set; }

    [Column("remark")] //備註
    public string remark { get; set; }  
    
  }
}