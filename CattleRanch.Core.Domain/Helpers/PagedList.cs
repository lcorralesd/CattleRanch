namespace CattleRanch.Core.Domain.Helpers;
public class PagedList<T> : List<T>
{
    public MetaData MetaData { get; set; }

    public PagedList(List<T> items, int count, int currentCount, int? pageNumber, int? pageSize)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize ?? 20,
            CurrentPage = pageNumber ?? 1,
            TotalPages = (int)Math.Ceiling(count / (double)(pageSize ?? 20)),
            CurrentCount = items.Count,
        };
        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int? pageNumber, int? pageSize)
    {
        var count = source.Count();
        var items = source
            .Skip(((pageNumber ?? 1) - 1) * (pageSize ?? 20))
            .Take(pageSize ?? 20).ToList();

        return new PagedList<T>(items, count, items.Count, pageNumber, pageSize);
    }
}
