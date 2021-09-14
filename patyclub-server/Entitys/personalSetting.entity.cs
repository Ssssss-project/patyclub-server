using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("PERSONAL_SETTING")]
  public class PersonalSetting
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