using GameCampaignTutorial.Model.Concrete;
using GameCampaignTutorial.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Concrete
{
    public class CampaignService : ICampaignService
    {
        private readonly List<Campaign> _campaigns = new List<Campaign>();

        public Task<bool> Add(Campaign entity)
        {
            _campaigns.Add(entity);
            return Task.FromResult(true);
        }

        public void Update(Campaign entity)
        {
            var campaign = Get(entity.Id);
            if (campaign == null)
            {
                Console.WriteLine("Kampanya bulunamadı!");
            }

            campaign.IsDeleted = entity.IsDeleted;
            campaign.Discount = entity.Discount;
            campaign.Description = entity.Description;
        }

        public Campaign Get(Guid id)
        {
            return _campaigns.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Campaign> GetAll()
        {
            return _campaigns;
        }
    }
}