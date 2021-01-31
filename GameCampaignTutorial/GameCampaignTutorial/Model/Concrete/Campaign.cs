using GameCampaignTutorial.Model.Abstract;

namespace GameCampaignTutorial.Model.Concrete
{
    public class Campaign : ModelBase
    {
        public string Description { get; set; }
        public double Discount { get; set; }
        public bool ValidOnAll { get; set; }
    }
}