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

        public TestController(ILogger<TestController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
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



    }
}
