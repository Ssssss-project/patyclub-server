using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.Service;


namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult Get(string account, string password)
        {
            User loginUser = _context.user.Find(account);

            // 帳號不存在
            if(loginUser == null) return StatusCode(401, new Response {message = "Account is not exist."});
            // 密碼錯誤
            if(loginUser.password != password) return StatusCode(401, new Response {message = "Account pass denied"});
            return Ok(new Response {message = "Account pass"});
        }

    }

    

}
