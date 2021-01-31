using GameCampaignTutorial.Model.Concrete;
using GameCampaignTutorial.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Concrete
{
    public class GameOrderService : IGameOrderService
    {
        private readonly List<GameOrder> _gameOrders = new List<GameOrder>();
        public Task<bool> Add(GameOrder entity)
        {
            _gameOrders.Add(entity);
            return Task.FromResult(true);
        }

        public void Update(GameOrder entity)
        {
            var gameOrder = Get(entity.Id);
            if (gameOrder == null)
            {
                Console.WriteLine("Oyun Siparişi bulunamadı!");
            }

            gameOrder.IsDeleted = entity.IsDeleted;
            gameOrder.AmountPaid = entity.AmountPaid;
            gameOrder.PurchaseDate = entity.PurchaseDate;
        }

        public GameOrder Get(Guid id)
        {
            return _gameOrders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameOrder> GetAll()
        {
            return _gameOrders;
        }
    }
}