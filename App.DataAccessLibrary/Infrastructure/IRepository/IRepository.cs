﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetT(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entity);

        Task<T?> GetTAsync(Expression<Func<T, bool>> predicate);
    }
}
