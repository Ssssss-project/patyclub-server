using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace patyclub_server.Entities
{
  [Table("USER")]
  public class User
  {
    [Column("account")] //帳號
    public string account { get; set; }

    [Column("password")] //密碼
    public string password { get; set; }

    [Column("name")] //姓名
    public string name { get; set; }

    [Column("phone")] //連絡電話
    public string phone { get; set; }

    [Column("email")] //伊媚兒
    public string email { get; set; }

    [Column("nickName")] //暱稱
    public string nickName { get; set; }

    [Column("sex")] //性別
    public string sex { get; set; }

    [Column("birthday")] //生日
    public string birthday { get; set; }

    [Column("emotionalState")] //感情狀態
    public string emotionalState { get; set; }

    [Column("activeState")] //活動狀態
    public string activeState { get; set; }

    [Column("country")] //所在國家
    public string country { get; set; }

    [Column("city")] //所在地區
    public string city { get; set; }

    [Column("introduction")] //簡介(關於我)
    public string introduction { get; set; }

    [Column("accountStatus")] //帳號狀態
    public string accountStatus { get; set; }

    [Column("forgetPwdToken")] //忘記密碼Token
    public string forgetPwdToken {get; set;}

    [Column("forgetPwdTokenCreatedDate")] //忘記密碼Token
    public string forgetPwdTokenCreatedDate {get; set;}
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