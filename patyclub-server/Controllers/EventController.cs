using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using patyclub_server.Entities;
using patyclub_server.Service;
using System.Collections.Generic;
using System.Linq;
using System;


namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private DBContext _context;
        private Random _random;
        private CoreService _coreService;

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
            _random = new Random();
            _coreService = new CoreService();
        }


        public class Event {
            public EventMst eventMst{get; set;}
            public List<EventAppendix> eventAppendixList{get; set;}
        }

        ///<summary>
        ///新建活動
        ///</summary>
        [Authorize]
        [HttpPost("createEvent")]
        public ActionResult createEvent()
        {
            string randString = _random.Next().ToString();

            var newEventMst = new EventMst{categoryId = 0, eventTitle = randString};
            _context.eventMst.Add(newEventMst);
            _context.SaveChanges();            

            _context.eventPersonnel.Add(new EventPersonnel{
                                                            userAccount = User.Claims.FirstOrDefault(a => a.Type == "userName").Value, 
                                                            eventMstId = newEventMst.id, 
                                                            permission = "OWNER"
                                                           });
            _context.SaveChanges();

            return Ok(new Response{message = "event created success.", data = new {id = newEventMst.id}});
        }


        ///<summary>
        ///更新活動
        ///</summary>
        /// <response code="500">日期格式錯誤，未成功更新</response>
        [HttpPost("updateEvent")]
        public ActionResult updateEvent(Event args){
            if (!_coreService.isDate(args.eventMst.eventStDate) ||
                !_coreService.isDate(args.eventMst.eventEdDate) ||
                !_coreService.isDate(args.eventMst.eventCreateDate) ||
                !_coreService.isDate(args.eventMst.examinationPassedDate) ||
                !_coreService.isDate(args.eventMst.signUpStDate) ||
                !_coreService.isDate(args.eventMst.signUpEdDate))
                return StatusCode(500, new Response{message = "日期格式錯誤，未成功更新"});
            _context.eventMst.Update(args.eventMst);


            // TODO 更新附件部分

            // 取得原始附件
            var eventAppendixResultList = _context.eventAppendix.Where(ep => ep.eventMstId == args.eventMst.id).ToList();

            // 補上新增附件
            foreach(var item in args.eventAppendixList){
                if (eventAppendixResultList.Find(a => a.id == item.id) == null)
                    _context.eventAppendix.Add(item); 
            }

            // 移除刪除附件
            foreach(var item in eventAppendixResultList){
                if (args.eventAppendixList.Find(a => a.id == item.id) == null)
                    _context.eventAppendix.Remove(item); // 硬刪除 考慮是否修改為軟刪除
            }

            _context.SaveChanges();
            return Ok(new Response{});
        }

        ///<summary>
        ///取得活動原始欄位
        ///</summary>
        [HttpPost("getRawEvent")]
        public ActionResult getRawEvent(int eventId){
            var resultEventMst = _context.eventMst.Where(a=>a.id == eventId).ToList();
            var resultEventAppendix = _context.eventAppendix.Where(a => a.eventMstId == eventId).ToList();

            return Ok(new Response {data = new {eventMst = resultEventMst, eventAppendix = resultEventAppendix}});
        }

        ///<summary>
        ///刪除活動
        ///</summary>
        [HttpDelete("deleteEvent")]
        public ActionResult deleteEvent(int eventMstId){

            // 移除活動主檔
            var eventResultList = _context.eventMst.Where(e => e.id == eventMstId);
            foreach(var item in eventResultList)
                _context.eventMst.Remove(item);

            // 移除活動附件
            var eventAppendixResultList = _context.eventAppendix.Where(e => e.eventMstId == eventMstId);
            foreach(var item in eventAppendixResultList)
                _context.eventAppendix.Remove(item);

            // 移除活動成員
            var eventPersonnelList = _context.eventPersonnel.Where(e => e.eventMstId == eventMstId);
            foreach(var item in eventPersonnelList)
                _context.eventPersonnel.Remove(item);

            _context.SaveChanges();
            return Ok(new Response{message = "eventMst, eventAppendix, eventPersonnel  remove success."});
        }


        /// <summary>
        /// 取得單筆活動
        /// </summary>
        /// <response code="404">Id is dismatch in Database.</response>
        [HttpGet("getEvent/{id}")]
        public ActionResult getEvent(int id)
        {
            var eventMstResult = (from em in _context.eventMst.Where(x => x.id == id)
                        join code in _context.sysCodeDtl.Where(x => x.sysCodeMstId == 2) on em.status equals code.codeName into statusCode
                        from sc in statusCode.DefaultIfEmpty()
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission} into owner
                        from o in owner.DefaultIfEmpty()
                        select new {em.id,
                                    em.categoryId,
                                    em.status,
                                    statusName = sc.codeDesc ?? string.Empty,
                                    em.cost,
                                    em.eventStDate,
                                    em.eventEdDate,
                                    em.eventCreateDate,
                                    em.examinationPassedDate,
                                    em.eventIntroduction,
                                    em.eventDetail,
                                    em.eventAttantion,
                                    em.tag,
                                    em.eventTitle,
                                    owner = o.userAccount ?? string.Empty,
                                    em.ageLimit,
                                    em.personLimit,
                                    timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                                Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress"
                                    }).ToList();


            if (eventMstResult.Count == 0)
                return StatusCode(404, new Response {message = "Id is dismatch in Database."});

            var appendixPathResultList = _context.eventAppendix.Where(ep => ep.eventMstId == id).ToList();

            var eventMember = _context.eventPersonnel.Where(ep => ep.eventMstId == id);

            return Ok(new Response {message = "", data = new {eventDtl = eventMstResult[0], eventAppendixList = appendixPathResultList, eventMember = eventMember.ToList()}});
        } 

        /// <summary>
        /// 取得精選活動清單
        /// </summary>
        [HttpGet("getSpecialEvent")]
        public ActionResult getSpecialEvent()
        {
            var resultEventMstList = from em in _context.eventMst
                                     join ep in _context.eventPersonnel
                                        on new {id = em.id, permission = "OWNER"} equals 
                                           new {id = ep.eventMstId, permission = ep.permission}
                                     where em.tag == "S"
                                     select new {
                                        em.id,
                                        em.eventTitle,
                                        em.eventIntroduction,
                                        em.signUpStDate,
                                        em.signUpEdDate,
                                        em.eventStDate,
                                        em.eventEdDate,
                                        owner = ep.userAccount
                                     };
                                            
            return Ok(new Response {message = "", data = resultEventMstList});
        }


        public class getEventWithConditionsArgs {
            public int? category {get; set;}
            public string TAG {get; set;}
            public List<string> queryList {get; set;}
            public string nonCompleteEvent {get; set;}
            public string sortBy {get; set;}
        };
        /// <summary>
        /// 依條件篩選活動
        /// </summary>
        /// <remarks>
        /// nonCompleteEvent: IF nonCompleteEvent is not null then limit eventEdDate must large than now and eventEdDate must is valid date format
        /// sortBy: 
        /// </remarks>
        [HttpPost("getEventWithConditions")]
        public ActionResult getEventWithConditions(getEventWithConditionsArgs args)
        {

            var resultEventMstList = _context.eventMst.ToList();

            // 套用篩選條件
            if (args.category != null) 
                resultEventMstList = resultEventMstList.Where(b => b.categoryId == args.category).ToList();
            if (args.TAG != ""  && args.TAG != null) 
                resultEventMstList = resultEventMstList.Where(b => b.tag == args.TAG).ToList();
            if (args.nonCompleteEvent != "" && args.nonCompleteEvent!= null)
                resultEventMstList = resultEventMstList.Where(b => {
                    if (!_coreService.isDate(b.eventEdDate))
                        return false;
                    else 
                        return Convert.ToDateTime(b.eventEdDate).CompareTo(DateTime.Now) > 0;
                }).ToList();

            if (args.queryList != null)
            {
                foreach (var query in args.queryList)
                {
                    resultEventMstList = resultEventMstList.Where(b => b.eventTitle.Contains(query)).ToList();
                }
            }

            // 套用排序
            if (args.sortBy == "eventStDate"){
                resultEventMstList = resultEventMstList.OrderBy(e => e.eventStDate).ToList();
            }else if(args.sortBy == "hot"){
                resultEventMstList = resultEventMstList.OrderBy(e => e.eventStDate).ToList();
            }



            var result = (from em in resultEventMstList
                        join ec in _context.eventCategory on em.categoryId equals ec.id into category
                        from c in category.DefaultIfEmpty()
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission} into subEp
                        from owner in subEp.DefaultIfEmpty()
                        join ap in _context.eventAppendix.Where(a => a.category == "P") on em.id equals ap.eventMstId into subAp
                        from cover in subAp.DefaultIfEmpty()
                        select new {
                        em.id,
                        em.categoryId,
                        categoryName = c?.categoryName ?? string.Empty,
                        em.eventTitle,
                        em.eventIntroduction,
                        em.signUpStDate,
                        em.signUpEdDate,
                        em.eventStDate,
                        em.eventEdDate,
                        owner = owner?.userAccount ?? string.Empty,
                        coverPath = cover?.appendixPath ?? string.Empty,
                        timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                        Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress"
                        }).ToList();


                                            
            return Ok(new Response {message = "", data = result});
        }

        /// <summary>
        /// 取得我的活動
        /// </summary>
        [HttpPost("getMyEvent")]
        public ActionResult getMyEvent(string account)
        {

            var resultEventMstList = (from ep in _context.eventPersonnel.Where(a => a.userAccount == account)
                                     join em in _context.eventMst on ep.eventMstId equals em.id
                                     select em).ToList();

            var result = (from em in resultEventMstList
                        join ec in _context.eventCategory on em.categoryId equals ec.id into category
                        from c in category.DefaultIfEmpty()
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission} into subEp
                        from owner in subEp.DefaultIfEmpty()
                        join ap in _context.eventAppendix.Where(a => a.category == "P") on em.id equals ap.eventMstId into subAp
                        from cover in subAp.DefaultIfEmpty()
                        select new {
                        em.id,
                        em.categoryId,
                        categoryName = c?.categoryName ?? string.Empty,
                        em.eventTitle,
                        em.eventIntroduction,
                        em.signUpStDate,
                        em.signUpEdDate,
                        em.eventStDate,
                        em.eventEdDate,
                        owner = owner?.userAccount ?? string.Empty,
                        coverPath = cover?.appendixPath ?? string.Empty,
                        timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                        Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress"
                        }).ToList();


                                            
            return Ok(new Response {message = "", data = result});
        }

        
        // [HttpGet("testA")]
        // public ActionResult testA(string A, string B){
        //     Console.WriteLine("is 空字串");
        //     Console.WriteLine(A == "");
        //     Console.WriteLine("is null");
        //     Console.WriteLine(A == null);
        //     Console.WriteLine("is isNullOrEmpty");
        //     Console.WriteLine(_coreService.isNullOrEmpty(A));
            
        //     return Ok(new Response());

        // }
    }




    

}
