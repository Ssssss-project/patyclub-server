using Microsoft.AspNetCore.Mvc;


namespace patyclub_server.Controllers
{
    public class BaseController : ControllerBase
    {


    }



    public class Response
    {
        public bool isSuccess {get; set;} // 回傳狀態
        public string message {get; set;} // 回傳訊息
        public object data {get; set;} // 回傳資料
    }
}
