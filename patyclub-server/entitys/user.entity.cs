using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace patyclub_server.Entities
{
  [Table("User")]
  public class User
  {
    [Column("id")]
    public int id { get; set; }

    [Column("name")]
    public string name { get; set; }

    [Column("phone")]
    public string phone { get; set; }

    [Column("remark")]
    public string remark { get; set; }
  }

  public class UserService
  {
    public DBContext _context;

    public UserService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<User> GetUsers() {
      return _context.user.ToList();
    }
  }
}