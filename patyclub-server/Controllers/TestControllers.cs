using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using patyclub_server.Entities;
using patyclub_server.Service;
using patyclub_server.Core;
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

        [HttpGet("testGetCateList")]
        public ActionResult testGetCateList(int startId){
            var cateList = _context.eventCategory.ToList();
            Console.WriteLine(String.Join(", ",_eventService.getCateList(cateList, startId)));
            return Ok();
        }

    }
}