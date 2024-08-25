using System.Collections;
using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

/// <summary>
/// Provides functionality to evaluate TeamCoty queries against a TeamCity server wherein the type of the data is known.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ITeamCityQueryable<T> : IQueryable<T>, IAsyncEnumerable<T>
{

}

internal sealed class TeamCityQueryable<T> : ITeamCityQueryable<T>
{
    private readonly IAsyncQueryProvider provider;

    public TeamCityQueryable(IAsyncQueryProvider provider)
    {
        Expression = Expression.Constant(this);
        this.provider = provider;
    }

    public TeamCityQueryable(IAsyncQueryProvider provider, Expression expression)
    {
        Expression = expression;
        this.provider = provider;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return provider.ExecuteEnumerable<T>(Expression).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return provider.ExecuteAsyncEnumerable<T>(Expression, cancellationToken).GetAsyncEnumerator(cancellationToken);
    }

    public Type ElementType => typeof(T);
    public Expression Expression { get; }
    public IQueryProvider Provider => provider;
}
