using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("PERSONAL_SETTING")]
  public class PersonalSetting
  {
    [Column("id")] //設定ID
    public int id { get; set; }

    [Column("category")] //設定類別
    public string category { get; set; }
  }

  public class PersonalSettingService
  {
    public DBContext _context;

    public PersonalSettingService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<PersonalSetting> GetPersonalSettings() {
      return _context.personalSetting.ToList();
    }
  }
}