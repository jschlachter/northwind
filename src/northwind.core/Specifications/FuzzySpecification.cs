using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Northwind.Core.Entities;
using Northwind.Core.Interfaces;

namespace Northwind.Core.Specifications
{
    public class FuzzySpecification<TEntity, TId>:BaseSpecification<TEntity, TId>
        where TEntity: class, IIdentifiable<TId>
    {
        public FuzzySpecification(int skip, int take, string queryString, params string[] properties)
            : base(BuildPredicate(queryString, properties))
        {
            ApplyPaging(skip, take);
        }

        public static Expression<Func<TEntity, bool>> BuildPredicate(string queryString, params string[] properties)
        {
            var type = typeof(TEntity);
            var predicate = PredicateBuilder.False<TEntity>();

            var pe = Expression.Parameter(type, "entity");

            var contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            var lower = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);

            predicate = properties.Aggregate(predicate, (current, p) =>
            {
                var pi = type.GetProperty(p);
                var accessor = Expression.Property(pe, pi);
                var mex = Expression.Call(
                            Expression.Call(accessor, lower),
                            contains,
                            Expression.Constant(queryString));

                return predicate.Or(Expression.Lambda<Func<TEntity, bool>>(mex, pe));
            });

            return predicate;
        }

        static Expression<Func<TEntity, string>> GetLambda(IEnumerable<string> propertyNames)
        {
            var p = Expression.Parameter(typeof(TEntity), "entity");
            Expression expr = p;

            expr = propertyNames.Aggregate(expr, (current, propertyName) => {
                return Expression.Property(current, propertyName);
            });

            return Expression.Lambda<Func<TEntity, string>>(expr, p);
        }
    }
}
