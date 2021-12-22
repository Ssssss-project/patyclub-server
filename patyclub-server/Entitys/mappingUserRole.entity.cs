using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_USER_ROLE")]
  public class MappingUserRole
  {
    [Column("userAccount")] //使用者帳戶
    public string userAccount { get; set; }

    [Column("roleId")] //角色ID
    public int roleId { get; set; }
  }

  public class MappingUserRoleService
  {
    public DBContext _context;

    public MappingUserRoleService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<MappingUserRole> GetMappingUserRoles() {
      return _context.mappingUserRole.ToList();
    }
  }
}