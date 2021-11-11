using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.Service;
using System.Collections.Generic;
using System.Linq;


namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        ///<summary>
        ///新建活動
        ///</summary>
        [HttpPost("createEvent")]
        public ActionResult createEvent(EventMst eventMst)
        {
            _context.eventMst.Add(eventMst);
            return Ok();
        }

        /// <summary>
        /// 取得精選活動清單
        /// </summary>
        [HttpGet("getSpecialEvent")]
        public ActionResult getSpecialEvent()
        {
            List<EventMst> resultEventMstList = _context.eventMst
                                            .Where(b => b.tag.Equals("S"))
                                            .ToList();
            return Ok(new Response {message = "", data = resultEventMstList});
        }

    }

    

}
