using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_PERMISSION_ROLE")]
  public class MappingPermissionRole
  {
    [Column("permissionId")] //權限ID
    public int permissionId { get; set; }

    [Column("roleId")] //角色ID
    public int roleId { get; set; }

  }

  public class MappingPermissionRoleService
  {
    public DBContext _context;

    public MappingPermissionRoleService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<MappingPermissionRole> GetMappingPermissionRoles() {
      return _context.mappingPermissionRole.ToList();
    }
  }
}