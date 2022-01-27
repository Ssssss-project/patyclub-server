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
    public class CodeController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<CodeController> _logger;
        private IConfiguration _configuration;

        public CodeController(ILogger<CodeController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }


        /// <summary>
        /// 取得代碼群組清單
        /// </summary>
        [HttpGet("getCodeMstList")]
        public ActionResult getCodeMstList(){
            var codeMstResult = _context.sysCodeMst.ToList();
            return Ok(new Response{data = codeMstResult});
        }

        /// <summary>
        /// 取得代碼組
        /// </summary>
        [HttpGet("getCodeDtl")]
        public ActionResult getCodeDtl(string mstId){
            var codeDtlResult = _context.sysCodeDtl.Where(a => a.sysCodeMstId == Convert.ToInt64(mstId)).ToList();
            return Ok(new Response{data = codeDtlResult});
        }

    }
}