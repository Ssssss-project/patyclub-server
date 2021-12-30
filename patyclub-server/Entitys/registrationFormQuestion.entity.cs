using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("REGISTRATION_FORM_QUESTION")]
  public class RegistrationFormQuestion
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] //題目ID
    public int id { get; set; }

    [Column("EventMstId")] //活動ID
    public int EventMstId { get; set; }

    [Column("category")] //題目類型
    public string category { get; set; }

    [Column("content")] //題目內容
    public string content { get; set; }

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