using System.Collections.Generic;
using System;
using System.Linq;

public enum logCategoryEnums{
    eventTouch,
    pageTouch,
    querySearch
}

public static class logCategoryEnumsExtend{
    public static string getString(this logCategoryEnums me){
        switch(me){
            case logCategoryEnums.eventTouch:
                return "eventTouchXX";
            case logCategoryEnums.pageTouch:
                return "pageTouchXX";
            case logCategoryEnums.querySearch:
                return "querySearchXX";
            default:
                return "Error";
        }
    }

    public static string CC(this List<int> tmp){
        return tmp[0].ToString();
    }


}