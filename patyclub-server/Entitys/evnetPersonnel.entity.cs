using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_PERSONNEL")]
  public class EvnetPersonnel
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

  public class EvnetPersonnelService
  {
    public DBContext _context;

    public EvnetPersonnelService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<EvnetPersonnel> GetEvnetPersonnels() {
      return _context.evnetPersonnel.ToList();
    }
  }
}