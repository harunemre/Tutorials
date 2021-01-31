using GameCampaignTutorial.Model.Enum;
using System;

namespace GameCampaignTutorial.Model.Abstract
{
    public interface IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public Genre Genre { get; set; }
    }
}