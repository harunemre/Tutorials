using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Abstract
{
    public interface IService<T>
    {
        Task<bool> Add(T entity);

        void Update(T entity);

        T Get(Guid id);

        IEnumerable<T> GetAll();
    }
}