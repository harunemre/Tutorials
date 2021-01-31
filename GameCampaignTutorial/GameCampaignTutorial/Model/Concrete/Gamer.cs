using GameCampaignTutorial.Model.Abstract;
using GameCampaignTutorial.Model.Enum;
using System;

namespace GameCampaignTutorial.Model.Concrete
{
    public class Gamer : ModelBase, IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Genre Genre { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNumber { get; set; }
    }
}