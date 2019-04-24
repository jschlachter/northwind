using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Northwind.Core.Interfaces
{
    public interface ISpecification<TEntity>:ISpecification<TEntity, int>
        where TEntity: class, IIdentifiable<int>
    {
    }

    public interface ISpecification<TEntity, TId> where TEntity: class, IIdentifiable<TId>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled { get;}
    }
}
