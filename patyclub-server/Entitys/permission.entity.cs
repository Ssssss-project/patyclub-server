using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("PERMISSION")]
  public class Permission
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

  public class PermissionService
  {
    public DBContext _context;

    public PermissionService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<Permission> GetPermissions() {
      return _context.permission.ToList();
    }
  }
}