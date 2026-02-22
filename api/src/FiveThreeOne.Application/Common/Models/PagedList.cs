namespace FiveThreeOne.Application.Common.Models
{
    public record PagedList<T>(
        int PageNumber,
        int TotalPages,
        int TotalCount,
        bool HasPreviousPage,
        bool HasNextPage,
        List<T> Items);
}
