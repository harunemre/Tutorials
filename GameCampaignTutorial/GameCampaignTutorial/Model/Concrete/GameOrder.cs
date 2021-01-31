using GameCampaignTutorial.Model.Abstract;
using System;

namespace GameCampaignTutorial.Model.Concrete
{
    public class GameOrder : ModelBase
    {
        public Game Game { get; set; }
        public Gamer Gamer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double AmountPaid { get; set; }
    }
}