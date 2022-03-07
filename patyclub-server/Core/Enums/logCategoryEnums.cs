using System.Collections.Generic;
using System;
using System.Linq;

public enum logCategoryEnums{
    eventTouch,
    pageTouch,
    querySearch
}

// public static class logCategoryEnumsExtend{
//     public static string getString(this logCategoryEnums me){
//         switch(me){
//             case logCategoryEnums.eventTouch:
//                 return "eventTouch";
//             case logCategoryEnums.pageTouch:
//                 return "pageTouch";
//             case logCategoryEnums.querySearch:
//                 return "querySearch";
//             default:
//                 return "Error";
//         }
//     }
// }