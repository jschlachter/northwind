using System;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Core.Entities;
using Northwind.Core.Interfaces;

namespace Northwind.Core.Specifications
{
    public class FuzzySpecification<TEntity, TId>:BaseSpecification<TEntity, TId>
        where TEntity: class, IIdentifiable<TId>
    {
        public FuzzySpecification(int skip, int take, string queryString)
            : base(_ => true)
        {
            ApplyPaging(skip, take);
        }

        public static Expression<Func<TEntity, bool>> BuildPredicate(string queryString, params string[] properties)
        {
            throw new NotImplementedException("Method not implemented");
        }
    }
}
