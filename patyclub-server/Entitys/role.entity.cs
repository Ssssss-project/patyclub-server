using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("ROLE")]
  public class Role
  {
    [Column("id")] //角色ID
    public int id { get; set; }

    [Column("name")] //角色名稱
    public string name { get; set; }
  }

  public class RoleService
  {
    public DBContext _context;

    public RoleService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<Role> GetRoles() {
      return _context.role.ToList();
    }
  }
}