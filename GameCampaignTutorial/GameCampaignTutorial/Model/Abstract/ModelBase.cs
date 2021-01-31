using System;

namespace GameCampaignTutorial.Model.Abstract
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}