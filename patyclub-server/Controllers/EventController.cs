using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.Service;


namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<LoginController> _logger;

        public EventController(ILogger<LoginController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public ActionResult Post(EventMst eventMst)
        {
            
            return Ok();
        }

    }

    

}
