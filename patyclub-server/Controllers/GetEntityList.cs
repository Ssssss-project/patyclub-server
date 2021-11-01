using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using patyclub_server.Service;
using System.Linq;
using System;
using System.Collections.Generic;


namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetEntityListController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<GetEntityListController> _logger;

        public GetEntityListController(ILogger<GetEntityListController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getAllUser")]
        public ActionResult getAllUser()
        {
            List<User> resultUserList = _context.user.ToList();
            return Ok(new Response {data = resultUserList});
        }

        [HttpGet("getActiveUser")]
        public ActionResult getActiveUser()
        {
            List<User> resultUserList = _context.user
                                            .Where(b => b.accountStatus.Equals("Active"))
                                            .ToList();
            return Ok(new Response {data = resultUserList});
        }



        [HttpGet("getEventCategory")]
        public ActionResult getEventCategory()
        {

            List<EventCategory> resultEventCategoryList = _context.eventCategory
                                            // .Where(b => b.enable.Equals("Y"))
                                            .ToList();
            EventService eventService = new EventService();
            CateNode result = eventService.getCateTree(resultEventCategoryList, new EventCategory {id = 0, categoryName = "ROOT"});
            return Ok(new Response {data = result});
            // return Ok(new Response {data = new CateNode {cateId = 0, cateName = "ROOT"}});
        }


    }

    

}
