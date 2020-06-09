using System;
using System.Collections.Generic;
using System.Text;

namespace FeaturesExtensionMethods
{
    public static class Extensions
    {
        public static int Count<T>(this IEnumerable<T> source)
        {
            int count = 0;
            foreach (var item in source)
            {
                count++;
            }
            return count;
        }
    }
}
