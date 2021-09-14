using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_USER_ROLE")]
  public class MappingUserRole
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