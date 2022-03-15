using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_DTL")]
  public class SysCodeDtl
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //參數ID
    public int id { get; set; }

    [Column("sysCodeMstKeyword")] //參數識別碼
    public string sysCodeMstKeyword { get; set; }
    
    [Column("codeName")] //參數名稱
    public string codeName { get; set; }

    [Column("codeDesc")] //參數內容
    public string codeDesc { get; set; }

  }
}