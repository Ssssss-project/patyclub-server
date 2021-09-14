using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("AUTO_COMPLETE_LIST")]
  public class AutoCompleteList
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

  public class AutoCompleteListService
  {
    public DBContext _context;

    public AutoCompleteListService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<AutoCompleteList> GetAutoCompleteLists() {
      return _context.autoCompleteList.ToList();
    }
  }
}