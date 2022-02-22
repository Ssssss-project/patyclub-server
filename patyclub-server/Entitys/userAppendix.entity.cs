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

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //附件ID
    public int id { get; set; }

    [Column("category")] //附件類別
    public string category { get; set; }

    [Column("appendixPath")] //附件路徑
    public string appendixPath { get; set; }
  }
}