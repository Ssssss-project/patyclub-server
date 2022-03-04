using System.Collections.Generic;
using System.Linq;
using System;

namespace extendFunction {
    public static class linqExtend{
        // public static IEnumerable<T> getChildCount<T>(this IEnumerable<T> me, Func<IEnumerable<T>, T> child){
        //     return (from c in child 
        //             // group c by c.mstId into cg

        //             select c.Key);
        // }
        public static IEnumerable<string> TestExtend<T>(this IEnumerable<T> a, Func<T, string> b){
        // IEnumerable<int> o = new IEnumerable<int>{};
        return (from tt in a select b(tt));
    }
    }
}