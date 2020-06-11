using System;
using System.Collections.Generic;
using System.Text;

namespace CustomFiltering
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in source)
            {
                yield return item;
            }
        }
    }
}
