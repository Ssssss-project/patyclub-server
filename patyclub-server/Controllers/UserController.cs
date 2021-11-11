using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.Service;
using System.Linq;
using System;
using System.Collections.Generic;

namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        ///<summary>
        ///註冊帳號
        ///</summary>
        [HttpPost("Register")]
        public ActionResult Register(User user)
        {
            User resultUser = _context.user.Find(user.account);
            
            // 帳號已存在
            if(resultUser != null) return StatusCode(409, new Response {message = "Account is already exist! Please try another account."});
            _context.user.Add(user);
            _context.SaveChanges();
            return Ok(new Response {message = "Account create complete."});
        }

        ///<summary>
        ///登入密碼驗證
        ///</summary>
        [HttpPost("login")]
        public ActionResult login(string account, string password)
        {
            User loginUser = _context.user.Find(account);

            // 帳號不存在
            if(loginUser == null) return StatusCode(401, new Response {message = "Account is not exist."});
            // 密碼錯誤
            if(loginUser.password != password) return StatusCode(401, new Response {message = "Account pass denied"});
            return Ok(new Response {message = "Account pass"});
        }

        ///<summary>
        ///忘記密碼
        ///</summary>
        [HttpPost("forgetPwd")]
        public ActionResult forgetPwd(string userEmail = "patyclub9453@gmail.com")
        {
            List<User> resultUserList = _context.user
                                            .Where(b => b.email.Equals(userEmail))
                                            .ToList();
            
            if (resultUserList.Count > 1)
            {
                return StatusCode(409, new Response{message = "There are more than on account that Email Match."});
            }

            User user = resultUserList[0];

            try
            {
                
                MailService mailService = new MailService();
                SecurityService securityService = new SecurityService();
                List<MailUser> mailUserList = new List<MailUser>();
                mailUserList.Add(new MailUser(user.name, user.email));

                string mailTitle = "PATYCLUB 忘記密碼";
                string mailBody = String.Format(
                    @"
                        <h1 style=""text-align: center;"">HI~ {0}</h1>
                        <p style=""text-align: center;""><strong><em>忘記密碼了，很苦惱嗎?</em></strong></p>
                        <div style=""padding-left: 40px;"">
                        <p style=""padding-left: 40px;"">別怕</p>
                        <p style=""padding-left: 40px;"">我給你一個網址</p>
                        <p style=""padding-left: 40px;"">去那裏吧!</p>
                        <p style=""padding-left: 40px;"">去那裏修改你的密碼!</p>
                        <p style=""padding-left: 40px;"">別再忘了喔!</p>
                        <p style=""padding-left: 40px;"">{1}</p>
                        <p style=""padding-left: 40px;"">測試SHA256</p>
                        <p style=""padding-left: 40px;"">{2}</p>
                        <p>&nbsp;</p>
                        <p style=""text-align: right;"">PATYCLUB 小天使</p>
                        </div>
                    "
                    , user.name
                    ,"https://www.google.com/"
                    ,BitConverter.ToString(securityService.string2SHA256(user.account)).Replace("-", "")
                    );

                // Console.WriteLine(mailBody);

                mailService.sendMail(
                    mailService.HTMLMail(
                        mailUserList,
                        mailTitle,
                        mailBody
                ));

                return Ok(new Response{message = "Send Mail Success."});
            }
            catch (System.Exception)
            {
                return StatusCode(500, new Response{message = "Something wrong.. Send Mail Failed."});
                throw;
            }

        }

        /// <summary>
        /// 取得所有使用者
        /// </summary>
        [HttpGet("getAllUser")]
        public ActionResult getAllUser()
        {
            List<User> resultUserList = _context.user.ToList();
            return Ok(new Response {data = resultUserList});
        }

        /// <summary>
        ///     取得活動中使用者
        /// </summary>
        [HttpGet("getActiveUser")]
        public ActionResult getActiveUser()
        {
            List<User> resultUserList = _context.user
                                            .Where(b => b.accountStatus.Equals("Active"))
                                            .ToList();
            return Ok(new Response {data = resultUserList});
        }

    }
}
