using GameCampaignTutorial.Model.Abstract;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Abstract
{
    public interface IValidationService<T> where T : IPerson
    {
        Task<bool?> Validate(T model);
    }
}