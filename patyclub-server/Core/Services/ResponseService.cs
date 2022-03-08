using Microsoft.AspNetCore.Mvc;

namespace patyclub_server.Core.Service
{
    public class Response
    {
        public string message {get; set;} // 回傳訊息
        public string sysErrMsg {get; set;} // 系統錯誤訊息
        public object data {get; set;} // 回傳資料
    }

}