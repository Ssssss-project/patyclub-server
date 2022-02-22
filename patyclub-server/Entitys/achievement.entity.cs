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
}