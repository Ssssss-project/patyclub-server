using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using patyclub_server.Entities;
using patyclub_server.Core.Service;
using patyclub_server.Core;
using System.Linq;
using System;
using System.Collections.Generic;

namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<LogController> _logger;
        private IConfiguration _configuration;
        private EventService _eventService;

        public LogController(ILogger<LogController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _eventService = new EventService();
        }

        ///<summary>
        /// 紀錄LOG
        ///</summary>
        ///<remarks>
        /// 0 eventTouch: eventId
        ///
        /// 1 pageTouch: pageId
        ///
        /// 2 querySearch: searchQueryString
        ///</remarks>
        [HttpPost("addLog")]
        public ActionResult addLog(addLogArgs args){
            string currentUser = User.Claims.FirstOrDefault(a => a.Type == "account")?.Value;
            _context.clientLog.Add(new ClientLog{logCategory = args.logCate.ToString(), userAccount = currentUser, targetSeq = args.targetSeq, logDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")});
            _context.SaveChanges();
            return Ok(new Response());
        }

        /// <summary>
        /// 取得所有LOG
        /// </summary>
        [HttpGet("getAllLog")]
        public ActionResult getAllLog(){
            return Ok(new Response {data = _context.clientLog.OrderBy(c => c.logDate).ToList()});
        }

        /// <summary>
        /// 取得前十筆活動瀏覽LOG
        /// </summary>
        [Authorize]
        [HttpGet("getTop10PersonalEventTouchLog")]
        public ActionResult getTop10PersonalEventTouchLog(){
            var account = User.Claims.FirstOrDefault(a => a.Type == "account").Value;
            var resultLog = (
                from res in (
                    from cl in _context.clientLog
                    where cl.userAccount == account
                    && cl.logCategory == "eventTouch"
                    group cl by new {userAccount = cl.userAccount, targetSeq = cl.targetSeq} into cl_distinct
                    select new {
                        userAccount = cl_distinct.Key.userAccount,
                        targetSeq = cl_distinct.Key.targetSeq,
                        logDate = cl_distinct.Max(x => x.logDate),
                        }
                )
                join em in _context.eventMst on res.targetSeq equals em.id.ToString()
                orderby res.logDate descending
                select em
            ).Skip(1).Take(10).ToList();

            _eventService.getEventCardInfo(_context, resultLog, account);
            return Ok(new Response {data = resultLog});
        }


    }
}
