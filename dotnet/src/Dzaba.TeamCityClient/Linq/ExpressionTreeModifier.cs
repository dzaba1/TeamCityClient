using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal class ExpressionTreeModifier<T> : ExpressionVisitor
{
    private readonly IQueryable<T> _queryableData;

    public ExpressionTreeModifier(IQueryable<T> queryableData)
    {
        ArgumentNullException.ThrowIfNull(queryableData, nameof(queryableData));

        _queryableData = queryableData;
    }

    protected override Expression VisitConstant(ConstantExpression c)
    {
        if (c.Type == typeof(TeamCityQueryable<T>))
            return Expression.Constant(_queryableData);
        else
            return c;
    }
}
