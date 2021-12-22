using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_MST")]
  public class SysCodeMst
  {
    [Column("id")] //參數類別ID
    public int id { get; set; }

    [Column("name")] //參數類別
    public string name { get; set; }

    [Column("remark")] //備註
    public string remark { get; set; }  }

  public class SysCodeMstService
  {
    public DBContext _context;

    public SysCodeMstService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<SysCodeMst> GetSysCodeMsts() {
      return _context.sysCodeMst.ToList();
    }
  }
}