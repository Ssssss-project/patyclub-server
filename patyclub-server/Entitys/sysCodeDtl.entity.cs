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

    [Column("sysCodeMstId")] //參數類別ID
    public int sysCodeMstId { get; set; }
    
    [Column("codeName")] //參數名稱
    public string codeName { get; set; }

    [Column("codeDesc")] //參數內容
    public string codeDesc { get; set; }

  }

  public class SysCodeDtlService
  {
    public DBContext _context;

    public SysCodeDtlService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<SysCodeDtl> GetSysCodeDtls() {
      return _context.sysCodeDtl.ToList();
    }
  }
}