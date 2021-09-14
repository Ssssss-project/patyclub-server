using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("SYS_CODE_MST")]
  public class SysCodeMst
  {
    [Column("id")]
    public int id { get; set; }

    [Column("name")]
    public string name { get; set; }

    [Column("phone")]
    public string phone { get; set; }

    [Column("status")]
    public string status { get; set; }

    [Column("remark")]
    public string remark { get; set; }
  }

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