using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;


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

        // [HttpGet("{account}")]
        // public User Get(string account)
        // {
        //     User testList = _context.user.Find(account);
        //     return testList;
        // }

        [HttpGet]
        public Response Get(string account, string pwd)
        {
            User loginUser = _context.user.Find(account);
            if(loginUser.password == pwd) return new Response("Success", "Account Pass", null);
            return new Response("Success", "Account Denied", null);
        }

    }

    public class Response
    {
        public Response()
        {

        }
        public Response(string _status, string _message, object _data){
            status = _status;
            message = _message;
            data = _data;
        }
        string status; // 回傳狀態
        string message; // 回傳訊息
        object data; // 回傳資料
    }
}
