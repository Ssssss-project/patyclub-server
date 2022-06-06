using System.Collections.Generic;
using patyclub_server.Entities;
using System;
using System.Linq;
using patyclub_server.extendFunction;
namespace patyclub_server.Core.Service
{
    public class CateNode {
        public int cateId {get; set;}
        public string cateName {get; set;}
        public List<CateNode> childNode {get; set;}
    }
    public class EventService {
        public CateNode getCateTree(List<EventCategory> cateList, EventCategory currentCate){
            CateNode currnetNode = new CateNode{cateId = currentCate.id, cateName = currentCate.categoryName}; // 新建自身節點
            currnetNode.childNode = new List<CateNode>();
            foreach (var cate in cateList) //尋找自己的所有子節點
            {
                if (cate.parentId == currentCate.id) // 當找到子節點時
                {
                    currnetNode.childNode.Add(getCateTree(cateList, cate)); // 讓子節點再去找他們的子節點，找完之後再把他們加到自身的子節點清單
                }
            }
            return currnetNode; // 最後回傳自身節點回到上一層
        }

        public List<int> getCateList(List<EventCategory> cateList, int currentCateId){
            List<int> tmpList = new List<int>{currentCateId};
            foreach (var cate in cateList) //尋找自己的所有子節點
            {
                if (cate.parentId == currentCateId) // 當找到子節點時
                {
                    tmpList.AddRange(getCateList(cateList, cate.id)); // 讓子節點再去找他們的子節點，找完之後再把他們加到自身的子節點清單
                }
            }
            return tmpList; // 最後回傳自身節點回到上一層
        }

        public List<object> getSourceCateList(List<EventCategory> cateList, int currentCateId){
            EventCategory currentCate = cateList.Find(a => a.id == currentCateId);
            if(currentCate is null)
                return new List<object>{};
            List<object> tmpList = new List<object>{new {id = currentCateId, name = currentCate.categoryName}};
            if(currentCate.parentId != 0)
                tmpList.AddRange(getSourceCateList(cateList, currentCate.parentId));
            return tmpList;
        }

        public class eventCardInfo{
            public int id {get; set;}
            public int categoryId {get; set;}
            public string categoryName {get; set;}
            public string eventTitle {get; set;}
            public string eventIntroduction {get; set;}
            public string signUpStDate {get; set;}
            public string signUpEdDate {get; set;}
            public string eventStDate {get; set;}
            public string eventEdDate {get; set;}
            public string owner {get; set;}
            public int memberCount {get; set;}
            public int memberLimit {get; set;}
            public string statusDesc {get; set;}
            public string coverPath {get; set;}
            public string timeStatus {get; set;}
            public string userPersonnel {get; set;}
            public bool isWatcher {get; set;}
        }

        public List<eventCardInfo> getEventCardInfo(DBContext _context, List<EventMst> eventMst, string logingUser){
            List<eventCardInfo> result =  eventMst.Select(em => new eventCardInfo{
                id = em.id,
                categoryId = em.categoryId,
                categoryName = _context.eventCategory.Where(x => x.id == em.categoryId).Select(x => x.categoryName).ToList().FirstOrDefault(),
                eventTitle = em.eventTitle,
                eventIntroduction = em.eventIntroduction,
                signUpStDate = em.signUpStDate,
                signUpEdDate = em.signUpEdDate,
                eventStDate = em.eventStDate,
                eventEdDate = em.eventEdDate,
                owner = _context.eventPersonnel.Where(x => x.eventMstId == em.id && x.permission == "OWNER").Select(x => x.userAccount).ToList().FirstOrDefault(),
                memberCount = _context.eventPersonnel.Where(x => x.permission != "WATCHER" && x.eventMstId == em.id).Count(),
                memberLimit = em.personLimit,
                statusDesc = em.status?.getCodeDesc(_context, "eventStatus"),
                coverPath = _context.eventAppendix.Where(x => x.category == "P" && x.eventMstId == em.id).Select(x => x.appendixPath).ToList().FirstOrDefault(),
                timeStatus = Convert.ToDateTime(em.eventStDate).CompareTo(DateTime.Now) > 0?"comingSoon":
                                Convert.ToDateTime(em.eventEdDate).CompareTo(DateTime.Now) < 0?"expired":"inProgress",
                userPersonnel = logingUser != null?(_context.eventPersonnel.Where(x => x.eventMstId == em.id && x.userAccount == logingUser && x.permission != "WATCHER").Select(x => x.permission).ToList().FirstOrDefault()):"",
                isWatcher = _context.eventPersonnel.Where(x => x.eventMstId == em.id && x.userAccount == logingUser && x.permission == "WATCHER").Any()
            }).ToList();
            
            return result;
        }
    }
}