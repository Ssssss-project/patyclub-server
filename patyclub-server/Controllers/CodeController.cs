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
        public ActionResult getCodeDtl(string mstKeyword){
            var codeDtlResult = _context.sysCodeDtl.Where(a => a.sysCodeMstKeyword == mstKeyword).OrderBy(a => a.orderSeq).ToList();
            return Ok(new Response{data = codeDtlResult});
        }

        /// <summary>
        /// 新增代碼群組
        /// </summary>
        [HttpPost("addCodeMst")]
        public ActionResult addCodeMst(SysCodeMst sysCodeMst){
            var codeMstResult = _context.sysCodeMst.Add(sysCodeMst);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼群組新增成功"});
        }

        /// <summary>
        /// 新增代碼
        /// </summary>
        [HttpPost("addCodeDtl")]
        public ActionResult addCodeDtl(SysCodeDtl sysCodeDtl){
            var codeMstResult = _context.sysCodeDtl.Add(sysCodeDtl);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼新增成功"});
        }

        /// <summary>
        /// 刪除代碼群組
        /// </summary>
        [HttpDelete("removeCodeMst")]
        public ActionResult removeCodeMst(string sysCodeMstKeyword){
            SysCodeMst item = new SysCodeMst{ keyword = sysCodeMstKeyword };
            _context.sysCodeMst.Remove(item);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼群組刪除成功"});
        }

        /// <summary>
        /// 刪除代碼
        /// </summary>
        [HttpDelete("removeCodeDtl")]
        public ActionResult removeCodeDtl(int sysCodeDtlId){
            SysCodeDtl item = new SysCodeDtl{ id = sysCodeDtlId };
            _context.sysCodeDtl.Remove(item);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼刪除成功"});
        }

        /// <summary>
        /// 更新代碼群組
        /// </summary>
        [HttpPost("updateCodeMst")]
        public ActionResult updateCodeMst(SysCodeMst sysCodeMst){
            _context.sysCodeMst.Update(sysCodeMst);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼群組更新成功"});
        }

        /// <summary>
        /// 更新代碼
        /// </summary>
        [HttpPost("updateCodeDtl")]
        public ActionResult updateCodeDtl(SysCodeDtl sysCodeDtl){
            _context.sysCodeDtl.Update(sysCodeDtl);
            _context.SaveChanges();
            return Ok(new Response{message = "代碼更新成功"});
        }

    }
}