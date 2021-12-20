using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost("createEvent")]
        public ActionResult createEvent(EventMst eventMst)
        {
            _context.eventMst.Add(eventMst);
            _context.SaveChanges();
            return Ok();
        }


        // public class Event {
        //     public EventMst eventMst{get; set;}
        //     public List<EventAppendix> eventAppendixList{get; set;}
        // }

        /// <summary>
        /// 取得精選活動清單
        /// </summary>
        [HttpGet("getEvent/{id}")]
        public ActionResult getEvent(int id)
        {
            // Event resultEvent = new Event();
            // List<EventMst> resultEventMstList = _context.eventMst
            //                                 .Where(b => b.id.Equals(id))
            //                                 .ToList();

            var result = from em in _context.eventMst
                                     join code in _context.sysCodeDtl on em.status equals code.codeName where code.sysCodeMstId == 2
                                     where em.id == id
                                     select new {em,
                                                 statusName = code.codeDesc};

            // if (resultEventMstList.ToList().Count == 0)
            //     return StatusCode(404, new Response {message = "Id is dismatch in Database."});

            
            // var aa = from code in _context.sysCodeDtl where code.sysCodeMstId == 2 select code.codeName;
            // var eventAppendix = from ea in _context.eventAppendix
            //                     where ea.eventMstId == id
            //                     select ea;

            // var test = from code in _context.sysCodeDtl where code.sysCodeMstId == 2 where code.codeName == "T" select code.codeDesc;

            return Ok(new Response {message = "", data = result.ToList()});
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
