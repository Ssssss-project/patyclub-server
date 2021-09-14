using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("USER_APPENDIX")]
  public class UserAppendix
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

  public class UserAppendixService
  {
    public DBContext _context;

    public UserAppendixService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<UserAppendix> GetUserAppendixs() {
      return _context.userAppendix.ToList();
    }
  }
}