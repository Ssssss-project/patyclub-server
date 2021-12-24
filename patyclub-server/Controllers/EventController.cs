using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using patyclub_server.Entities;
using patyclub_server.Service;
using System.Collections.Generic;
using System.Linq;
using System;


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
        /// 取得單筆活動
        /// </summary>
        [HttpGet("getEvent/{id}")]
        public ActionResult getEvent(int id)
        {
            // Event resultEvent = new Event();
            // List<EventMst> resultEventMstList = _context.eventMst
            //                                 .Where(b => b.id.Equals(id))
            //                                 .ToList();

            var result = from em in _context.eventMst.Where(x => x.id == id)
                        join code in _context.sysCodeDtl.Where(x => x.sysCodeMstId == 2) on em.status equals code.codeName
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission}
                        select new {em.id,
                                    em.categoryId,
                                    em.status,
                                    statusName = code.codeDesc,
                                    em.cost,
                                    em.eventStDate,
                                    em.eventEdDate,
                                    em.eventCreateDate,
                                    em.examinationPassedDate,
                                    em.eventIntroduction,
                                    em.eventDetail,
                                    em.eventAttantion,
                                    em.tag,
                                    em.eventTitle,
                                    owner = ep.userAccount
                                    };


            if (result.ToList().Count == 0)
                return StatusCode(404, new Response {message = "Id is dismatch in Database."});

            return Ok(new Response {message = "", data = result.ToList()});
        } 

        /// <summary>
        /// 取得精選活動清單
        /// </summary>
        [HttpGet("getSpecialEvent")]
        public ActionResult getSpecialEvent()
        {
            var resultEventMstList = from em in _context.eventMst
                                     join ep in _context.eventPersonnel
                                        on new {id = em.id, permission = "OWNER"} equals 
                                           new {id = ep.eventMstId, permission = ep.permission}
                                     where em.tag == "S"
                                     select new {
                                        em.id,
                                        em.eventTitle,
                                        em.eventIntroduction,
                                        em.signUpStDate,
                                        em.signUpEdDate,
                                        em.eventStDate,
                                        em.eventEdDate,
                                        owner = ep.userAccount
                                     };
                                            
            return Ok(new Response {message = "", data = resultEventMstList});
        }


        public class getEventWithConditionsArgs {
            public int? category {get; set;}
            public string TAG {get; set;}
            public string eventStDate {get; set;}
        };
        /// <summary>
        /// 依條件篩選活動
        /// </summary>
        [HttpPost("getEventWithConditions")]
        public ActionResult getEventWithConditions(getEventWithConditionsArgs args)
        {

            var resultEventMstList = _context.eventMst.ToList();

            if (args.category != null) 
                resultEventMstList = resultEventMstList.Where(b => b.categoryId == args.category).ToList();
            if (args.TAG != "") 
                resultEventMstList = resultEventMstList.Where(b => b.tag == args.TAG).ToList();
            if (args.eventStDate != "")
                resultEventMstList = resultEventMstList.Where(b => Convert.ToDateTime(b.eventStDate) == Convert.ToDateTime(args.eventStDate)).ToList();

            var result = from em in resultEventMstList
                        join ec in _context.eventCategory on args.category equals ec.id
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission}
                        where em.tag == "S"
                        select new {
                        em.id,
                        em.eventTitle,
                        em.eventIntroduction,
                        em.signUpStDate,
                        em.signUpEdDate,
                        em.eventStDate,
                        em.eventEdDate,
                        owner = ep.userAccount
                        };


                                            
            return Ok(new Response {message = ""});
        }

    }

    

}
