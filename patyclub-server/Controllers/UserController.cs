using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using patyclub_server.Entities;
using patyclub_server.Service;
using patyclub_server.Core;
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
        private IConfiguration _configuration;
        private Random _random;

        public UserController(ILogger<UserController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _random = new Random();
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


        public class loginArgs{
            public string account {get; set;}
            public string password {get; set;}
        }
        ///<summary>
        ///登入密碼驗證
        ///</summary>
        [HttpPost("login")]
        public ActionResult login(loginArgs args)
        {
            User loginUser = _context.user.Find(args.account);
            JwtHelpers jwtHelpers = new JwtHelpers(_configuration);

            // 帳號不存在
            if(loginUser == null) return StatusCode(401, new Response {message = "Account is not exist."});
            // 密碼錯誤
            if(loginUser.password != args.password) return StatusCode(401, new Response {message = "Account pass denied"});

            string token = jwtHelpers.GenerateToken(loginUser.name, "ADMIN");
            return Ok(new Response {message = "Account pass", data = token});
        }

        public class forgetPwdArgs{
            public string userEmail{get; set;}
        }
        ///<summary>
        ///忘記密碼
        ///</summary>
        [HttpPost("forgetPwd")]
        public ActionResult forgetPwd(forgetPwdArgs args)
        {
            List<User> resultUserList = _context.user
                                            .Where(b => b.email.Equals(args.userEmail))
                                            .ToList();
            
            if (resultUserList.Count > 1)
            {
                return StatusCode(409, new Response{message = "There are more than on account that Email Match."});
            }
            else if(resultUserList.Count == 0)
            {
                return StatusCode(404, new Response{message = "There didn't have account that Email Match."});
            }

            User user = resultUserList[0];

            try
            {
                
                MailService mailService = new MailService();
                SecurityService securityService = new SecurityService();
                List<MailUser> mailUserList = new List<MailUser>();
                string token = BitConverter.ToString(securityService.string2SHA256(_random.NextDouble().ToString())).Replace("-", "");
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
                        <p>&nbsp;</p>
                        <p style=""text-align: right;"">PATYCLUB 小天使</p>
                        </div>
                    "
                    , user.name
                    ,_configuration["ClientAddress"] + "/user/resetPassword/" + token
                    );



                mailService.sendMail(
                    mailService.HTMLMail(
                        mailUserList,
                        mailTitle,
                        mailBody
                ));

                // 儲存Token
                user.forgetPwdToken = token;
                user.forgetPwdTokenCreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                _context.SaveChanges();


                return Ok(new Response{message = "Send Mail Success."});
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new Response{message = "Something wrong.. Send Mail Failed.", sysErrMsg = e.ToString()});
                throw;
            }

        }

        public class changePwdWithTokenArgs{
            public string token{get; set;}
            public string newPwd{get; set;}
        }
        [HttpPut("changePwdWithToken")]
        public ActionResult changePwdWithToken(changePwdWithTokenArgs args)
        {
            String dueTime = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss");
            List<User> userList = _context.user
                            .Where(u => u.forgetPwdToken == args.token)
                            .Where(u => u.forgetPwdTokenCreatedDate != null && dueTime.CompareTo(u.forgetPwdTokenCreatedDate) < 0)
                            .ToList();

            if(userList.Count == 0)
            {
                return StatusCode(404, new Response{message = "Token not found or Token is overdue"});
            }
            else if(userList.Count > 1)
            {
                return StatusCode(500, new Response{message = "Something wrong! that is almost impossible for appear same token as the same time."});
            }

            userList[0].password = args.newPwd;
            userList[0].forgetPwdToken = null;
            userList[0].forgetPwdTokenCreatedDate = null;
            _context.SaveChanges();
            
            return Ok(new Response{message = "change Success"});
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
        [Authorize]
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
