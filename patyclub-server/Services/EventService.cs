using System.Collections.Generic;
using patyclub_server.Entities;
namespace patyclub_server.Service
{
    public class EventService {
        public class CateNode {
            public CateNode(int _cateId, string _cateName) {
                cateId = _cateId;
                cateName = _cateName;
            }
            public int cateId;
            public string cateName;
            public List<CateNode> childNode;
        }

        public CateNode getCateTree(List<EventCategory> cateList, EventCategory currentCate){
            CateNode currnetNode = new CateNode(currentCate.id, currentCate.categoryName);
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