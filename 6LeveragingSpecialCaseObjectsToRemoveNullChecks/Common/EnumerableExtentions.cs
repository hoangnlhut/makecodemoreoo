using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LeveragingSpecialCaseObjectsToRemoveNullChecks.Common
{
    public static class EnumerableExtentions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T obj in sequence)
              action(obj);
        }
    }
}
