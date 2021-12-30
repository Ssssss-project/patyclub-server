using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("ACHIEVEMENT")]
  public class Achievement
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //成就ID
    public int id { get; set; }

    [Column("describe")] //成就描述
    public string describe { get; set; }

    [Column("goal")] //成就目標
    public int goal { get; set; }

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