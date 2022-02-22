using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_USER_ACHIEVEMENT")]
  public class MappingUserAchievement
  {
    [Column("userAccount")] //使用者帳戶
    public string userAccount { get; set; }

    [Column("achievementId")] //成就ID
    public int achievementId { get; set; }

    [Column("currentProgress")] //目前進度
    public string currentProgress { get; set; }

  }
}