using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("MAPPING_EVENT_TAG")]
  public class MappingEventTag
  {
    [Column("eventMstId")] //活動ID
    public int eventMstId { get; set; }

    [Column("tagId")] //TAG ID
    public int tagId { get; set; }

  }
}