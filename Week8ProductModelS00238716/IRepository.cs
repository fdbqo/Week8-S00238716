﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        
        T Add(T entity);

        T Update(T entity);
        void AddRange(IEnumerable<T> entities);
        
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        
    }
}
