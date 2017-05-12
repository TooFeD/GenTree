using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GenTree.DAL.Interfaces;

namespace GenTree.DAL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DataContext { get; set; }

        public BaseRepository(DbContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual T Add(T entity)
        {
            return DataContext.Set<T>().Add(entity);
        }

        public virtual bool Delete(T entity)
        {
            return DataContext.Set<T>().Remove(entity) != null;
        }

        public virtual List<T> GetAll()
        {
            var temp = DataContext.Set<T>().ToList();
            return temp;
        }

        public virtual T GetById<TID>(TID id)
        {
            return DataContext.Set<T>().Find(id);
        }

        public virtual List<T> GetById<TID>(List<TID> idList)
        {
            var result = new List<T>();
            idList.ForEach(id =>
            {
                var item = DataContext.Set<T>().Find(id);
                if (item != null)
                {
                    result.Add(item);
                }
            });
            return result;
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().Any(predicate);
        }

    }
}