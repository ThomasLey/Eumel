using System;
using System.Collections;
using System.Linq;

namespace Eumel.Domse.Core.Extensions
{
    public static class LinqExtensions
    {
        public static T Single<T>(this IEnumerable source)
        {
            if (source == null) throw new ArgumentNullException();

            return source.Cast<T>().Single();
        }
    }
}