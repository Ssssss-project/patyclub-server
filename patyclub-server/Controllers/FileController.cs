// 參考資料 : https://ithelp.ithome.com.tw/articles/10196584

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using patyclub_server.Entities;
using patyclub_server.Core.Service;
namespace patyclub_server.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private DBContext _context;

        private readonly ILogger<FileController> _logger;
        private IConfiguration _configuration;

        private EventService _eventService;

        public FileController(ILogger<FileController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }



        /// <summary>
        /// 上傳Slide
        /// </summary>
        [HttpPost("uploadSlide")]
        public async Task<ActionResult> uploadSlide(IFormFile file)
        {
            if(file.Length == 0)
                return StatusCode(404, new Response{message = "File not found."});
            string path = @".\Data\slide\" + file.FileName;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new Response{});
        }

        /// <summary>
        /// 檢視Slide清單
        /// </summary>
        [HttpGet("getSlideList")]
        public ActionResult getSlideList()
        {
            string[] files = Directory.GetFiles("./Data/slide/", "*.*", SearchOption.AllDirectories);

            return Ok(new Response{data = files});
        }

        /// <summary>
        /// 刪除Slide
        /// </summary>
        [HttpDelete("deleteSlide")]
        public ActionResult deleteSlide(string filename)
        {
            string path = "./Data/slide/" + filename;
            if(!System.IO.File.Exists(path))
                return StatusCode(404, new Response{message = String.Format("File not found : \"{}\"", path)});

            System.IO.File.Delete(path);

            return Ok(new Response{message = "File delete success."});
        }
    }
}
