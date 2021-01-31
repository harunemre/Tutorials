using GameCampaignTutorial.Model.Concrete;
using GameCampaignTutorial.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Concrete
{
    public class GamerService : IGamerService
    {
        private readonly IValidationService<Gamer> _validationService;
        private readonly List<Gamer> _gamers = new List<Gamer>();

        public GamerService(IValidationService<Gamer> validationService)
        {
            _validationService = validationService;
        }

        public async Task<bool> Add(Gamer entity)
        {
            var result = await _validationService.Validate(entity);
            if (result == false)
            {
                return false;
            }

            _gamers.Add(entity);
            return true;
        }

        public void Update(Gamer entity)
        {
            var gamer = Get(entity.Id);
            if (gamer == null)
            {
                Console.WriteLine("Oyuncu bulunamadı!");
            }

            gamer.BirthDate = entity.BirthDate; 
            gamer.Email = entity.Email; 
            gamer.Genre = entity.Genre; 
            gamer.IdentityNumber = entity.IdentityNumber; 
            gamer.IsDeleted = entity.IsDeleted; 
            gamer.Name = entity.Name; 
            gamer.Surname = entity.Surname;             
        }

        public Gamer Get(Guid id)
        {
            return _gamers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Gamer> GetAll()
        {
            return _gamers;
        }
    }
}