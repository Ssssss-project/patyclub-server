using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("USER_APPENDIX")]
  public class UserAppendix
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("id")] //附件ID
    public int id { get; set; }

    [Column("appendixPath")] //附件路徑
    public string appendixPath { get; set; }
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