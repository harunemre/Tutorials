using System;
using System.Collections.Generic;

namespace ClassMetotDemo.Abstract
{
    public interface IManager<T>
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int Id);

        int GetCount();

        IEnumerable<T> GetAll();
    }
}