﻿using Dataflow.Server.Repositories;
using System.Linq.Expressions;

namespace Dataflow.Server.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
