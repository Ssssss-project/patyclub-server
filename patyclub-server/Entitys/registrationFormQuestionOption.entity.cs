using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("REGISTRATION_FORM_QUESTION_OPTION")]
  public class RegistrationFormQuestionOption
  {
    [Column("id")] //選項ID
    public int id { get; set; }

    [Column("questionId")] //題目ID
    public int questionId { get; set; }

    [Column("content")] //選項內容
    public string content { get; set; }

  }

  public class RegistrationFormQuestionOptionService
  {
    public DBContext _context;

    public RegistrationFormQuestionOptionService(DBContext context)
    {
      _context = context;
    }

    public IEnumerable<RegistrationFormQuestionOption> GetRegistrationFormQuestionOptions() {
      return _context.registrationFormQuestionOption.ToList();
    }
  }
}