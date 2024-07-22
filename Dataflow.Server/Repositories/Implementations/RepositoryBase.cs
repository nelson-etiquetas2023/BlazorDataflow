using Dataflow.Server.Data;
using Dataflow.Server.Repositories;
using Dataflow.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Dataflow.Server.Repository.Implementations
{
    public abstract class RepositoryBase<T>(AppDbContext dbcontext) : IRepositoryBase<T> where T : class
    {
        protected AppDbContext _dbcontext = dbcontext;

        public void Create(T entity) => _dbcontext.Set<T>().Add(entity);
        public void Update(T entity) => _dbcontext.Set<T>().Update(entity);
        public void Delete(T entity) => _dbcontext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _dbcontext.Set<T>().AsNoTracking() :
            _dbcontext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression , bool trackChanges) =>
            !trackChanges ? _dbcontext.Set<T>().Where(expression).AsNoTracking() :
            _dbcontext.Set<T>().Where(expression);

    }
}
