using System.Collections;
using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal sealed class TeamCityQueryable<T> : IQueryable<T>
{
    private readonly BaseQueryProvider provider;

    public TeamCityQueryable(BaseQueryProvider provider)
    {
        Expression = Expression.Constant(this);
        this.provider = provider;
    }

    public TeamCityQueryable(BaseQueryProvider provider, Expression expression)
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

    public Type ElementType => typeof(T);
    public Expression Expression { get; }
    public IQueryProvider Provider => provider;
}
