using System.Linq;

namespace Northwind.Infrastructure
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> PageForward<T>(this IQueryable<T> source, int pageSize, int pageNumber)
        {
            if (pageSize > 0)
            {
                if (pageNumber == 0)
                    pageNumber = 1;

                if (pageNumber > 0)
                    return source
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
            }

            return source;
        }
    }
}
