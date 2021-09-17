using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_USER_PERSONAL_SETTING")]
  public class MappingUserPersonalSetting
  {
    [Column("userAccount")] //使用者帳戶
    public string userAccount { get; set; }

    [Column("personalSettingId")] //個人化設定ID
    public int personalSettingId { get; set; }

    [Column("settingValue")] //設定值
    public string settingValue { get; set; }

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