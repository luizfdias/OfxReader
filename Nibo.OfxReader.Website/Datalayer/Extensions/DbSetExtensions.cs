using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Nibo.OfxReader.Website.Datalayer.Extensions
{
    public static class DbSetExtensions
    {
        public static TEntity AddIfNotExists<TEntity>(this DbSet<TEntity> dbSet, TEntity entity, Expression<Func<TEntity, bool>> predicate = null) where TEntity : class, new()
        {
            var entityFromBase = dbSet.FirstOrDefault(predicate);
            return entityFromBase == null ? dbSet.Add(entity) : entityFromBase;
        }
    }
}