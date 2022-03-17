using System.Collections.Generic;
using System.Linq;
using System;

namespace patyclub_server.extendFunction {
    public static class linqExtend{
        // private static object GetPropertyValue(object obj, string propertyName)
        // {
        //     return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        // }
        public static object getCol(this object source, string colName){
            return source.GetType().GetProperty(colName).GetValue(source)
                    // select s
                    ;
        }


        public static IEnumerable<object> jJoin<T, A>(this IEnumerable<T> source, IEnumerable<A> child, string parentKey, string childKey){
            return from s in source
                    join g in child.ToList()
                    on s.getCol(parentKey) equals g.getCol(childKey) into g2
                    from gg in g2.DefaultIfEmpty()
                    select new {s, gg}
                    // select s
                    ;    
        }

        public static IEnumerable<T> sSelect<T>(this IEnumerable<T> source, string parentKey){
            return from s in source
                    where s.getCol(parentKey).Equals("2")
                    select s
                    // select s
                    ;
        }

        public static IEnumerable<object> getChildCount<T, A>(this IEnumerable<T> source, IEnumerable<A> child, string parentKey, string childKey){
            return from s in source
                    join g in(
                        from c in child.ToList()
                        group c by c.getCol(childKey) into gc
                        // group c by c.GetType().GetProperty(childKey).GetValue(c) into gc
                        select new {key = gc.Key, cnt = gc.Count()}
                    )
                    on s.getCol(parentKey) equals g.key into g2
                    // on s.GetType().GetProperty(parentKey).GetValue(s) equals g.key into g2
                    from gg in g2.DefaultIfEmpty()
                    select new {data = s, cnt = gg?.cnt}
                    // select s
                    ;
        }



        public static IEnumerable<string> TestExtend<T>(this IEnumerable<T> a, string lastStr, Func<T, string> b){
        // IEnumerable<int> o = new IEnumerable<int>{};
        return (
            from tt in a 
            select b(tt) + lastStr
            );
        }
    }
}