using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.ResponseService;

namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController:ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        public ActionResult post(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}