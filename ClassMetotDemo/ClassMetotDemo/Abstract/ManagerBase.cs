using System.Collections.Generic;
using System.Linq;

namespace ClassMetotDemo.Abstract
{
    public abstract class ManagerBase<T> : IManager<T>
        where T : IEntity
    {
        private static readonly List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int Id)
        {
            return _entities[Id];
        }

        public int GetCount()
        {
            return _entities.Count;
        }

        public void Update(T entity)
        {
            var indexOfEntity = _entities.FindIndex(x => x.Id == entity.Id);
            if (indexOfEntity != -1)
            {
                _entities[indexOfEntity] = entity;
            }            
        }
    }
}