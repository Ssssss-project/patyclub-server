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
    }
}