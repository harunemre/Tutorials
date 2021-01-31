using GameCampaignTutorial.Model.Concrete;
using GameCampaignTutorial.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Concrete
{
    public class GameService : IGameService
    {
        private readonly List<Game> _games = new List<Game>();

        public Task<bool> Add(Game entity)
        {
            _games.Add(entity);
            return Task.FromResult(true);
        }

        public void Update(Game entity)
        {
            var game = Get(entity.Id);
            if (game == null)
            {
                Console.WriteLine("Oyun bulunamadı!");
            }

            game.Developer = entity.Developer;
            game.Name = entity.Name;
            game.Price = entity.Price;
            game.Rating = entity.Rating;
            game.ReleaseDate = entity.ReleaseDate;
            game.CampaignId = entity.CampaignId;
            game.IsDeleted = entity.IsDeleted;
        }

        public Game Get(Guid id)
        {
            return _games.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _games;
        }
    }
}