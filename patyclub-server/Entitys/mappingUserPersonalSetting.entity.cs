using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_USER_PERSONAL_SETTING")]
  public class MappingUserPersonalSetting
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

  public class MappingUserPersonalSettingService
  {
    public DBContext _context;

    public MappingUserPersonalSettingService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<MappingUserPersonalSetting> GetMappingUserPersonalSettings() {
      return _context.mappingUserPersonalSetting.ToList();
    }
  }
}