    public class Response
    {
        public string message {get; set;} // 回傳訊息
        public string sysErrMsg {get; set;} // 系統錯誤訊息
        public object data {get; set;} // 回傳資料
    }

    public class PageRequest{
        public int rownumPerPage {get; set;}
        public int requestPageNum {get; set;}
    }

    public class ResponseWithPage : Response{
        public int maxPageNum {get; set;}
        public int totalRownum {get; set;}
        public int currentPageNum {get; set;}
    }