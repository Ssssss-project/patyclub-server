using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.ResponseService;


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
        public ActionResult Get(string account, string pwd)
        {
            Response response = new Response {isSuccess = true, message = "Account Pass", data = null};
            try
            {
                User loginUser = _context.user.Find(account);
                if(loginUser.password == pwd) return Ok(new Response {isSuccess = true, message = "Account pass", data = null});
                return Ok(new Response {isSuccess = false, message = "Account pass denied", data = null});
            }
            catch (System.Exception)
            {
                // return NotFound(new Response {isSuccess = false, message = "Account not found", data = null});
                // throw;
                return StatusCode(100, "RRRRR");
            }


        }

    }

    

}
