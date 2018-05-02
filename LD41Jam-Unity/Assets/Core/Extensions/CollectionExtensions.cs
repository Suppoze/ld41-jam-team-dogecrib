using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class CollectionExtensions
    {
        public static T Pop<T>(this List<T> list)
        {
            var lastValue = list.Last();
            list.Remove(lastValue);
            return lastValue;
        }
        
        public static void Push<T>(this List<T> linkedList, T newElement)
        {
            linkedList.Add(newElement);
        }
    }
}