using Microsoft.AspNetCore.Mvc;

namespace patyclub_server.Service
{
    public class Response
    {
        public string message {get; set;} // 回傳訊息
        public object data {get; set;} // 回傳資料
    }

}