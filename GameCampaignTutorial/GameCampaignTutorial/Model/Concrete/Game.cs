using GameCampaignTutorial.Model.Abstract;
using System;

namespace GameCampaignTutorial.Model.Concrete
{
    public class Game : ModelBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CampaignId { get; set; }
    }
}