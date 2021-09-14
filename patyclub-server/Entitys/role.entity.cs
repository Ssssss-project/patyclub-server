using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("ROLE")]
  public class Role
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