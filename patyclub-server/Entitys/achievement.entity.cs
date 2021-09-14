using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("ACHIEVEMENT")]
  public class Achievement
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

  public class AchievementService
  {
    public DBContext _context;

    public AchievementService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<Achievement> GetAchievements() {
      return _context.achievement.ToList();
    }
  }
}