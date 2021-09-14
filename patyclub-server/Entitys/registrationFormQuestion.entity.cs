using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("REGISTRATION_FORM_QUESTION")]
  public class RegistrationFormQuestion
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

  public class RegistrationFormQuestionService
  {
    public DBContext _context;

    public RegistrationFormQuestionService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<RegistrationFormQuestion> GetRegistrationFormQuestions() {
      return _context.registrationFormQuestion.ToList();
    }
  }
}