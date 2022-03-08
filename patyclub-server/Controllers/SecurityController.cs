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
    public class SecurityController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<SecurityController> _logger;
        private IConfiguration _configuration;

        public SecurityController(ILogger<SecurityController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
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

        ///<summary>
        ///更新JWT
        ///</summary>
        [HttpGet("refreshJWT")]
        [Authorize]
        public ActionResult refreshJWT()
        {
            JwtHelpers jwtHelpers = new JwtHelpers(_configuration);

            User.Claims.Where(c => c.Type == "" || c.Type == "");
            string token = jwtHelpers.GenerateToken(User.Claims.FirstOrDefault(a => a.Type == "account").Value, User.Claims.FirstOrDefault(a => a.Type == "permission").Value);
            return Ok(new Response{message = "JWT refresh success.", data = token});
        }

    }
}
