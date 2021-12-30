using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("PERMISSION")]
  public class Permission
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //權限ID
    public int id { get; set; }

    [Column("functionName")] //功能名稱
    public string functionName { get; set; }

    [Column("actionCategory")] //操作類別
    public string actionCategory { get; set; }

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