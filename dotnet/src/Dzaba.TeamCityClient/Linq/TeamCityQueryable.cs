using System.Collections;
using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal sealed class TeamCityQueryable<T> : IQueryable<T>
{
    public TeamCityQueryable(IQueryProvider provider)
    {
        Expression = Expression.Constant(this);
        Provider = provider;
    }

    public TeamCityQueryable(IQueryProvider provider, Expression expression)
    {
        Expression = expression;
        Provider = provider;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)Provider.Execute(Expression)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Type ElementType => typeof(T);
    public Expression Expression { get; }
    public IQueryProvider Provider { get; }
}
