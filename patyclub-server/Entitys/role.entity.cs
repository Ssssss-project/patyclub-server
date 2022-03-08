using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("ROLE")]
  public class Role
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //角色ID
    public int id { get; set; }

    [Column("name")] //角色名稱
    public string name { get; set; }
  }
}