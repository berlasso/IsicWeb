using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SIACGral.Models
{
    /// <summary>
    /// Defines the LINQ extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Orders the sequence by specific column and direction.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="direction">If set to "asc" then ascending otherwise descending.</param>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
        {
            string methodName = string.Format("OrderBy{0}", direction.ToLower() == "asc" ? "" : "descending");
            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
            MemberExpression memberAccess = null;
            //
            foreach (var property in sortColumn.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }
            //
            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);
            MethodCallExpression result = Expression.Call(
                      typeof(Queryable),
                      methodName,
                      new[] { query.ElementType, memberAccess.Type },
                      query.Expression,
                      Expression.Quote(orderByLambda));
            //
            return query.Provider.CreateQuery<T>(result);
        }
    }
}