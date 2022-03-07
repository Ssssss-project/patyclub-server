using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using patyclub_server.Entities;
using patyclub_server.Core.Service;
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
        private EventService _eventService;

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
            _random = new Random();
            _coreService = new CoreService();
            _eventService = new EventService();
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
                                                            userAccount = User.Claims.FirstOrDefault(a => a.Type == "account").Value, 
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
            public YesNoEnums nonCompleteEvent {get; set;}
            public eventSortByEnums sortBy {get; set;}
            public eventPersonnel eventPersonnel {get; set;}
        };



        /// <summary>
        /// 依條件篩選活動
        /// </summary>
        /// <remarks>
        /// queryList: 查詢範圍「eventTitle, eventDetail, eventAttantion, eventIntroduction」
        ///
        /// nonCompleteEvent: IF nonCompleteEvent is "Yes" then limit eventEdDate must large than now and eventEdDate must is valid date format
        ///
        /// sortBy: Keyword in ("eventStDate_asc", "eventStDate_desc", "hot_asc", "hot_desc")
        ///
        /// eventPersonnel: Keyword in ("OWNER" "MEMBER" "WATCHER")
        /// </remarks>
        [HttpPost("getEventWithConditions")]
        public ActionResult getEventWithConditions(getEventWithConditionsArgs args)
        {
            var resultEventMstList = _context.eventMst.ToList();

            // 套用篩選條件
            if (args.category != null){
                List<int> cateList = _eventService.getCateList(_context.eventCategory.ToList(), args.category.GetValueOrDefault(0));
                resultEventMstList = (
                    from em in resultEventMstList.Where(b => cateList.Contains(b.categoryId))
                    select em
                    ).ToList();
            }
                
            if (args.TAG != ""  && args.TAG != null) 
                resultEventMstList = resultEventMstList.Where(b => b.tag == args.TAG).ToList();
            if (args.nonCompleteEvent == YesNoEnums.Yes)
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
                    resultEventMstList = resultEventMstList.Where(b => b.eventTitle.Contains(query) 
                                                                    || b.eventDetail.Contains(query)
                                                                    || b.eventAttantion.Contains(query)
                                                                    || b.eventIntroduction.Contains(query)).ToList();
                }
            }

            if (args.eventPersonnel == eventPersonnel.non_select){
                if (User.Claims.FirstOrDefault(u => u.Type == "account")?.Value == null)
                    return StatusCode(401, new Response{message = "if U want to use 'eventPersonnel' condition, U must login first"});
                resultEventMstList = (from em in resultEventMstList
                                      join ep in _context.eventPersonnel
                                      on new {id = em.id, permission = args.eventPersonnel.ToString(), userAccount = User.Claims.FirstOrDefault(a => a.Type == "account").Value} equals 
                                         new {id = ep.eventMstId, permission = ep.permission, userAccount = ep.userAccount}
                                      select em).ToList();
            }

            if (args.sortBy != eventSortByEnums.non_sort){
                // 套用排序
                if (args.sortBy == eventSortByEnums.eventStDate_asc){
                    resultEventMstList = 
                        (from em in resultEventMstList
                        orderby Convert.ToDateTime(em.eventStDate) ascending
                        select em
                        ).ToList();
                }else if (args.sortBy == eventSortByEnums.eventStDate_desc){
                    resultEventMstList = 
                        (from em in resultEventMstList
                        orderby Convert.ToDateTime(em.eventStDate) descending
                        select em
                        ).ToList();
                }else if(args.sortBy == eventSortByEnums.hot_asc){
                    resultEventMstList = 
                        (from em in resultEventMstList
                        join pCnt in (
                            from personnel in _context.eventPersonnel
                            where personnel.permission != "WATCHER"
                            group personnel by personnel.eventMstId into perG
                            select new {key = perG.Key, cnt = perG.Count()}
                        ) on em.id equals pCnt.key
                        orderby pCnt.cnt ascending
                        select em
                        ).ToList();
                }else if (args.sortBy == eventSortByEnums.hot_desc){
                    resultEventMstList = 
                        (from em in resultEventMstList
                        join pCnt in (
                            from personnel in _context.eventPersonnel
                            where personnel.permission != "WATCHER"
                            group personnel by personnel.eventMstId into perG
                            select new {key = perG.Key, cnt = perG.Count()}
                        ) on em.id equals pCnt.key
                        orderby pCnt.cnt descending
                        select em
                        ).ToList();
                }else{
                    return StatusCode(404, new Response{message = "Error 'sortBy' keyword: " + args.sortBy});
                }
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
            // return Ok(new Response ());
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
    }

}
