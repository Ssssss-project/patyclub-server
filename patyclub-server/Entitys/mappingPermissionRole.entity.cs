using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_PERMISSION_ROLE")]
  public class MappingPermissionRole
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