using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_DTL")]
  public class SysCodeDtl
  {
    [Column("id")] //參數ID
    public int id { get; set; }

    [Column("sysCodeMstId")] //參數類別ID
    public int sysCodeMstId { get; set; }

    [Column("content")] //參數內容
    public string content { get; set; }

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