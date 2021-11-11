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
    public class SecurityController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<SecurityController> _logger;

        public SecurityController(ILogger<SecurityController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        ///<summary>
        ///取得SHA256雜湊
        ///</summary>
        [HttpGet("getSHA256")]
        public ActionResult getSHA256(string str)
        {
            SecurityService securityService = new SecurityService();

            return Ok(new Response{message = "success", data = securityService.string2SHA256(str)});
        }

    }
}
