using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using patyclub_server.Core;
using Microsoft.AspNetCore.Authorization;

namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DBContext _context;
        private readonly JwtHelpers _jwt;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBContext context, JwtHelpers jwt)
        {
            _logger = logger;
            _context = context;
            _jwt = jwt;
        }

        [HttpGet]
        public string Get()
        {
            return _jwt.GenerateToken("test");;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Login()
        {
            var allValue = User.Claims.Select(c => new {c.Value, c.Type});
            var userName = allValue.FirstOrDefault(c => c.Type == "userName").Value;
            return Ok(userName);
        }
    }
}
