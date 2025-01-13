using Kreta.Shared.Models;
using System.Linq.Expressions;

namespace Kreta.Backend.Repos.Base
{
    public static class IQuerybleExtension
    {
        public static IQueryable<TEntity> FindByCondition<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IDbEntity<TEntity>,new()
        {
            return query.Where(expression);
        }
    }
}
