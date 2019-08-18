using System;
using System.Linq;
using System.Linq.Expressions;
using NonFactors.Mvc.Grid;

namespace AdminPanel.Common
{
    public class NumberContainsFilter : BaseGridFilter
    {
        public override Expression Apply(Expression expression)
        {
            if (Values.Count == 0 || Values.Any(string.IsNullOrEmpty))
                return null;

            return base.Apply(expression);
        }

        protected override Expression Apply(Expression expression, string value)
        {
            Expression valueExpression = Expression.Constant(value.ToUpper());
            var toStringMethod = typeof(int).GetMethod("ToString", new Type[0]);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            Expression toString = Expression.Call(expression, toStringMethod);

            return Expression.Call(toString, containsMethod, valueExpression);
        }
    }
}
