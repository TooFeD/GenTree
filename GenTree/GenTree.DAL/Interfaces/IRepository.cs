using System.Collections.Generic;

namespace GenTree.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById<TID>(TID id);
        T Add(T entity);
        bool Delete(T entity);
    }
}