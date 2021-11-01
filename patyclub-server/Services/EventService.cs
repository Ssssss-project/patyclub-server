using System.Collections.Generic;
using patyclub_server.Entities;
using System;
namespace patyclub_server.Service
{
    public class CateNode {
        public int cateId {get; set;}
        public string cateName {get; set;}
        public List<CateNode> childNode {get; set;}
    }
    public class EventService {
        public CateNode getCateTree(List<EventCategory> cateList, EventCategory currentCate){
            CateNode currnetNode = new CateNode{cateId = currentCate.id, cateName = currentCate.categoryName};
            currnetNode.childNode = new List<CateNode>();
            foreach (var cate in cateList)
            {
                if (cate.parentId == currentCate.id)
                {
                    currnetNode.childNode.Add(getCateTree(cateList, cate));
                }
            }
            return currnetNode;
        }
    }
}