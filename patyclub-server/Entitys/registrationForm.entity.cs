using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("REGISTRATION_FORM")]
  public class RegistrationForm
  {
    [Column("userAccount")] //使用者帳號
    public string userAccount { get; set; }

    [Column("eventMstId")] //活動ID
    public int eventMstId { get; set; }

    [Column("questionId")] //問題ID
    public int questionId { get; set; }

    [Column("content")] //填寫內容
    public string content { get; set; }

  }
}