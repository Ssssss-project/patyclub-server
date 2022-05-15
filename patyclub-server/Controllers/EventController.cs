using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using patyclub_server.Entities;
using patyclub_server.Core.Service;
using patyclub_server.extendFunction;
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
        ///<remark>
        ///當活動更新時，活動狀態一律更新為暫存中
        ///</remark>
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

            EventMst eventMst = args.eventMst;
            eventMst.status = "TEMP"; //修改狀態為暫存中
            _context.eventMst.Update(eventMst);


            // TODO 更新附件部分

            // 取得原始附件
            var eventAppendixResultList = _context.eventAppendix.Where(ep => ep.eventMstId == eventMst.id).ToList();

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
            var eventMstResult = _context.eventMst.Where(x => x.id == id).ToList();
            var result = (from em in eventMstResult
                        join code in _context.sysCodeDtl.Where(x => x.sysCodeMstKeyword == "eventStatus") on em.status equals code.codeName into statusCode
                        from sc in statusCode.DefaultIfEmpty()
                        join ep in _context.eventPersonnel
                        on new {id = em.id, permission = "OWNER"} equals 
                            new {id = ep.eventMstId, permission = ep.permission} into owner
                        from o in owner.DefaultIfEmpty()
                        join ep in (
                            from ep in _context.eventPersonnel
                            where ep.permission == "MEMBER" || ep.permission == "OWNER"
                            group ep by ep.eventMstId into epc
                            select new {key = epc.Key, cnt = epc.Count()}
                            )
                        on new {id = em.id} equals 
                            new {id = ep.key} into subEp2
                        from member in subEp2.DefaultIfEmpty()
                        from statusDesc in _context.sysCodeDtl
                        where statusDesc.sysCodeMstKeyword == "eventStatus" && statusDesc.codeName == em.status
                        select new {em.id,
                                    em.categoryId,
                                    em.status,
                                    statusName = sc?.codeDesc ?? string.Empty,
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
                                    owner = o?.userAccount ?? string.Empty,
                                    memberCount = member?.cnt ?? 0,
                                    statusDesc = statusDesc.codeDesc,
                                    em.ageLimit,
                                    memberLimit = em.personLimit,
                                    timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                                Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress"
                                    }).ToList();


            if (eventMstResult.Count == 0)
                return StatusCode(404, new Response {message = "Id is dismatch in Database."});

            var appendixPathResultList = _context.eventAppendix.Where(ep => ep.eventMstId == id).ToList();

            var eventMember = _context.eventPersonnel.Where(ep => ep.eventMstId == id);

            return Ok(new Response {message = "", data = new {eventDtl = result[0], eventAppendixList = appendixPathResultList, eventMember = eventMember.ToList()}});
        } 






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
            var logingUser = User.Claims.FirstOrDefault(u => u.Type == "account")?.Value;

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

            if (args.eventPersonnel != eventPersonnelEnums.non_select){
                if (logingUser == null)
                    return StatusCode(401, new Response{message = "if U want to use 'eventPersonnel' condition, U must login first"});
                resultEventMstList = (from em in resultEventMstList
                                      join ep in _context.eventPersonnel
                                      on new {id = em.id, permission = args.eventPersonnel.ToString(), userAccount = logingUser} equals 
                                         new {id = ep.eventMstId, permission = ep.permission, userAccount = ep.userAccount}
                                      select em).ToList();
            }



            var result = resultEventMstList.Select(em => new{
                em.id,
                em.categoryId,
                categoryName = _context.eventCategory.Where(x => x.id == em.categoryId).Select(x => x.categoryName).ToList().FirstOrDefault(),
                em.eventTitle,
                em.eventIntroduction,
                em.signUpStDate,
                em.signUpEdDate,
                em.eventStDate,
                em.eventEdDate,
                owner = _context.eventPersonnel.Where(x => x.eventMstId == em.id && x.permission == "OWNER").Select(x => x.userAccount).ToList().FirstOrDefault(),
                memberCount = _context.eventPersonnel.Where(x => x.permission != "WATCHER" && x.eventMstId == em.id).Count(),
                memberLimit = em.personLimit,
                statusDesc = em.status?.getCodeDesc(_context, "eventStatus"),
                coverPath = _context.eventAppendix.Where(x => x.category == "P" && x.eventMstId == em.id).Select(x => x.appendixPath).ToList().FirstOrDefault(),
                timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress",
                userPersonnel = logingUser != null?(_context.eventPersonnel.Where(x => x.eventMstId == em.id && x.userAccount == logingUser && x.permission != "WATCHER").Select(x => x.permission).ToList().FirstOrDefault()):"",
                isWatcher = _context.eventPersonnel.Where(x => x.eventMstId == em.id && x.userAccount == logingUser && x.permission == "WATCHER").Any()
            });

            if (args.sortBy != eventSortByEnums.non_sort){
                // 套用排序
                if (args.sortBy == eventSortByEnums.eventStDate_asc){
                    result = result.OrderBy(x => Convert.ToDateTime(x.eventStDate)).ToList();
                }else if (args.sortBy == eventSortByEnums.eventStDate_desc){
                    result = result.OrderByDescending(x => Convert.ToDateTime(x.eventStDate)).ToList();
                }else if(args.sortBy == eventSortByEnums.hot_asc){
                    result = result.OrderBy(x => x.memberCount).ToList();
                }else if (args.sortBy == eventSortByEnums.hot_desc){
                    result = result.OrderByDescending(x => x.memberCount).ToList();
                }else{
                    return StatusCode(404, new Response{message = "Error 'sortBy' keyword: " + args.sortBy});
                }
            }


            PaginationAttr paginationAttr = _coreService.getPageAttr(result.Count(), args.rownumPerPage, args.requestPageNum);
            if(paginationAttr.rownumPerPage != 0)
                result = result.Skip(paginationAttr.skipRownum).Take(paginationAttr.rownumPerPage).ToList();

            return Ok(new ResponseWithPage {
                message = "", 
                data = result, 
                maxPageNum = paginationAttr.maxPageNum, 
                currentPageNum = paginationAttr.currentPageNum,
                totalRownum = paginationAttr.totalRownum
                });
        }


        [Authorize]
        [HttpPut("joinEvent")]
        public ActionResult joinEvent(int eventId){
            _context.eventPersonnel.Add(new EventPersonnel{userAccount = User.Claims.FirstOrDefault(a => a.Type == "account").Value, eventMstId = eventId, permission = "MEMBER", status = "??"});
            _context.SaveChanges();
            return Ok(new Response{});
        }



        ///<summary>
        ///切換收藏狀態
        ///</summary>
        [Authorize]
        [HttpPut("switchWatchEvent")]
        public ActionResult switchWatchEvent(int eventId){
            string loginUser = User.Claims.FirstOrDefault(a => a.Type == "account").Value;
            string msg = "";
            var result = _context.eventPersonnel.Where(x => x.eventMstId == eventId && x.userAccount == loginUser && x.permission == "WATCHER");
            if (result.Any()){
                foreach (var item in result)
                    _context.eventPersonnel.Remove(item);
                    msg = "解除收藏成功";
            }
            else {
                _context.eventPersonnel.Add(new EventPersonnel{userAccount = loginUser, eventMstId = eventId, permission = "WATCHER", status = "??"});
                msg = "收藏成功";
            }
            _context.SaveChanges();
            return Ok(new Response{message = msg});
        }


        ///<summary>
        ///修改活動狀態
        ///</summary>
        [Authorize]
        [HttpPut("updateEventStatus")]
        public ActionResult updateEventStatus(updateEventStatusArgs args){
            string loginUserPermission = User.Claims.FirstOrDefault(a => a.Type == "permission").Value;
            
            if(!loginUserPermission.Contains("總管理")){
                return StatusCode(401, "Update Failed. Permission denied.");
            }

            EventMst resultEventMst = _context.eventMst.Where(e => e.id == args.eventId).FirstOrDefault();

            if(resultEventMst is null){
                return StatusCode(404, "EventMst not found.");
            }

            resultEventMst.status = args.status;

            _context.eventMst.Update(resultEventMst);
            _context.SaveChanges();

            return Ok(new Response{message = "update event status success. eventId = " + args.eventId.ToString() + ", status = " + args.status});
        }
    }

}
