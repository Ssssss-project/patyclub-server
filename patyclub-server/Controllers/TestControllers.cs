using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using patyclub_server.Entities;
using patyclub_server.Core.Service;
using patyclub_server.Core;
using patyclub_server.extendFunction;
using System.Linq;
using System;
using System.Collections.Generic;

namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<TestController> _logger;
        private IConfiguration _configuration;

        private EventService _eventService;

        public TestController(ILogger<TestController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _eventService = new EventService();
        }

        public class testIntPostArgs{
            public int? A {get; set;}
        }

        /// <summary>
        /// 測試intPost
        /// </summary>
        [HttpPost("testIntPost")]
        public ActionResult testIntPost(testIntPostArgs args)
        {
            return Ok(new Response{data = args.A.GetValueOrDefault(-1)});
        }

        /// <summary>
        /// testEnums
        /// </summary>
        [HttpPost("testEnums")]
        public ActionResult testEnums(YesNoEnums args)
        {
            return Ok(new Response{data =args.ToString()});
        }


        public class testPostEnumsArgs {
            public YesNoEnums YN {get; set;}
        }
        /// <summary>
        /// testPostEnums
        /// </summary>
        [HttpPost("testPostEnums")]
        public ActionResult testPostEnums(testPostEnumsArgs args)
        {
            string tmp = "";
            if(args.YN == YesNoEnums.Yes)
                tmp += "  YesNoEnums.Yes";
            if(args.YN == YesNoEnums.No)
                tmp += "  YesNoEnums.No";
            if(args.YN == 0)
                tmp += "  0";
            return Ok(new Response{message = tmp ,data =args.YN.ToString()});
        }

        /// <summary>
        /// testExtendFunc
        /// </summary>
        [HttpPost("testExtendFunc")]
        public ActionResult testExtendFunc()
        {
            var pContext = _context.eventMst;
            var cContext = _context.eventPersonnel;
            // var res = _context.eventMst.getCol("id");
            // var res = pContext.jJoin(cContext, "id", "eventMstId");
            // var res = pContext.sSelect("id");
            var res = pContext.getChildCount(cContext, "id", "eventMstId");
            // var res = _context.clientLog.TestExtend("555", x => x.logCategory + "0");
            return Ok(new Response{data = res.ToList()});
        }


        [HttpGet("testGetSourceCateList")]
        public ActionResult testGetSourceCateList(int startId){
            List<EventCategory> resultEventCategoryList = _context.eventCategory
                                            .Where(b => b.enable.Equals("Y"))
                                            .ToList();
            return Ok(new Response{data = _eventService.getSourceCateList(resultEventCategoryList, startId)});
        }



    }
}
