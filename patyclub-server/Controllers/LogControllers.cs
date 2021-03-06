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

        public LogController(ILogger<LogController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
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
        public ActionResult addLog(logCategoryEnums logCate, string targetSeq){
            string currentUser = User.Claims.FirstOrDefault(a => a.Type == "account")?.Value;
            _context.clientLog.Add(new ClientLog{logCategory = logCate.ToString(), userAccount = currentUser, targetSeq = targetSeq, logDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")});
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
            var resultLog = (
                from cl in _context.clientLog
                where cl.userAccount == User.Claims.FirstOrDefault(a => a.Type == "account").Value
                   && cl.logCategory == "eventTouch"
                orderby cl.logDate descending
                select cl
            ).Take(10).ToList();
            return Ok(new Response {data = resultLog});
        }


    }
}
