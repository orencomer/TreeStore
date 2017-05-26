﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TreeStore.Data.Interface
{
    public interface IRepository<T> where T :class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(long id, params string[] navigations);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where, params string[] navigations);
        // Gets all entities of type T
        IEnumerable<T> GetAll(params string[] navigations);
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations);
    }
}
