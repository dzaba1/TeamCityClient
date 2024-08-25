using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal interface IAsyncQueryProvider : IQueryProvider
{
    IEnumerable<T> ExecuteEnumerable<T>(Expression expression);
    IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(Expression expression, CancellationToken cancellationToken);
}
