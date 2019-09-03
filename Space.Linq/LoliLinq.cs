using System;
using System.Collections.Generic;
using System.Linq;

namespace Space.Linq
{
    public static class LoliLinq
    {
        public static IEnumerable<T> LoliNeedWhere<T>(this IEnumerable<T> source , Func<T, bool> predicate) where T : class
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        }

        public static IEnumerable<TOut> LoliWantToSelect<T,TOut> (this IEnumerable<T> source, Func<T, TOut> get) where T : class
        {
            foreach (var item in source)
                yield return get(item);
        }

        public static T  LoliNeedsInYou<T> (this IEnumerable<T> source, int index)
        {
            return source.ToArray()[index];
        }
    }
}
