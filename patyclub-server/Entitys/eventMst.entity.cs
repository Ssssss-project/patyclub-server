using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("EVENT_MST")]
  public class EventMst
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")] // 活動ID
    public int id { get; set; }

    [Column("categoryId")] //類別ID
    public int categoryId { get; set; }

    [Column("eventTitle")] //活動標題
    public string eventTitle { get; set; }

    [Column("status")] //活動狀態
    public string status { get; set; }

    [Column("cost")] //活動費用
    public string cost { get; set; }

    [Column("eventStDate")] //活動開始日期
    public string eventStDate { get; set; }

    [Column("eventEdDate")] //活動結束日期
    public string eventEdDate { get; set; }

    [Column("eventCreateDate")] //活動創建日期
    public string eventCreateDate { get; set; }

    [Column("examinationPassedDate")] //審核通過日期
    public string examinationPassedDate { get; set; }

    [Column("signUpStDate")] //報名開始日期
    public string signUpStDate { get; set; }

    [Column("signUpEdDate")] //報名結束日期
    public string signUpEdDate { get; set; }

    [Column("eventIntroduction")] //活動簡介
    public string eventIntroduction { get; set; }

    [Column("eventDetail")] //活動細項
    public string eventDetail { get; set; }

    [Column("eventAttantion")] //活動注意事項
    public string eventAttantion { get; set; }

    [Column("tag")] //活動標籤
    public string tag { get; set; }
    
    [Column("personLimit")] //人數限制
    public int personLimit { get; set; }

    [Column("ageLimit")] //年齡限制
    public string ageLimit { get; set; }
  }
}