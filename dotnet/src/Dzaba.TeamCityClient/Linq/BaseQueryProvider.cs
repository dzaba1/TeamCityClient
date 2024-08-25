using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal abstract class BaseQueryProvider : IQueryProvider
{
    public IQueryable CreateQuery(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        var elementType = expression.Type.GetGenericArguments().FirstOrDefault();
        var queryableType = typeof(TeamCityQueryable<>).MakeGenericType(elementType);
        return (IQueryable)Activator.CreateInstance(queryableType, this, expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        return new TeamCityQueryable<TElement>(this, expression);
    }

    public abstract object Execute(Expression expression);
    public abstract TResult Execute<TResult>(Expression expression);
}
