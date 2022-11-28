using System.Collections.Generic;
using System.Linq;

namespace Vaetech.Threading.Tasks
{
    public static class EnumerableExtension {
        public static TSource[] GetRange<TSource>(this IEnumerable<TSource> source, int index, int count)
        {
            int c = source.Count();
            var builder = new List<TSource>(c);

            foreach (TSource item in source)
            {
                builder.Add(item);
            }

            return builder.ToArray();
        }
    }
}
