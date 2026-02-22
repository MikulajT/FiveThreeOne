using FiveThreeOne.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace FiveThreeOne.Application.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize,
            CancellationToken ct = default)
        {
            var count = await source.CountAsync(ct);
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PagedList<T>(
                pageNumber,
                totalPages,
                count,
                pageNumber > 1,
                pageNumber < totalPages,
                items);
        }
    }
}
