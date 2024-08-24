namespace Dzaba.TeamCityClient;

/// <summary>
/// General one-page request.
/// </summary>
/// <typeparam name="T">Response type</typeparam>
/// <param name="start">Starting page</param>
/// <param name="itemsPerPage">Page count</param>
/// <returns>Items returned in a page.</returns>
public delegate IAsyncEnumerable<T> PagedRequestAsync<out T>(int start, int itemsPerPage);

/// <summary>
/// General one-page request with TeamCity locator.
/// </summary>
/// <typeparam name="T">Response type</typeparam>
/// <param name="locator">Locator object</param>
/// <returns>Items returned in a page</returns>
public delegate IAsyncEnumerable<T> LocatorPagedRequestAsync<out T>(Locator locator);

/// <summary>
/// Helper methods for getting all pages from TeamCity requests.
/// </summary>
public static class TeamCityPageExpander
{
    /// <summary>
    /// Enumerates all items from paging request.
    /// </summary>
    /// <typeparam name="T">Response type.</typeparam>
    /// <param name="request">One-page request handler.</param>
    /// <param name="itemsPerPage">Page count.</param>
    /// <returns>Async enumerable of all items.</returns>
    public static async IAsyncEnumerable<T> GetAllAsync<T>(PagedRequestAsync<T> request, int itemsPerPage)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var exit = false;
        var pageCount = 0;
        var prevItemsCount = -1;

        while (!exit)
        {
            var max = prevItemsCount < 0 ? itemsPerPage : prevItemsCount;
            var start = max * pageCount;

            var array = await GetPageAsync(request, itemsPerPage, start).ConfigureAwait(false);

            foreach (var item in array)
            {
                yield return item;
            }

            if (array.Length < itemsPerPage || (prevItemsCount < 0 && array.Length == 0))
            {
                exit = true;
            }
            else
            {
                prevItemsCount = array.Length;
                pageCount++;
            }
        }
    }

    /// <summary>
    /// Enumerates all items from paging request.
    /// </summary>
    /// <typeparam name="T">Response type.</typeparam>
    /// <param name="request">One-page request handler.</param>
    /// <param name="baseLocator">Base locator object.</param>
    /// <param name="itemsPerPage">Page count.</param>
    /// <returns>Async enumerable of all items.</returns>
    public static IAsyncEnumerable<T> GetAllAsync<T>(LocatorPagedRequestAsync<T> request, Locator baseLocator, int itemsPerPage)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        ArgumentNullException.ThrowIfNull(baseLocator, nameof(baseLocator));

        return GetAllAsync((s, m) =>
        {
            var locator = baseLocator.Copy();
            locator.Count = m;
            locator.Start = s;

            return request(locator);
        }, itemsPerPage);
    }

    private static async Task<T[]> GetPageAsync<T>(PagedRequestAsync<T> request, int itemsPerPage, int start)
    {
        var page = request(start, itemsPerPage);

        return page == null ? Array.Empty<T>() : await page.ToArrayAsync().ConfigureAwait(false);
    }
}
