using GameCampaignTutorial.Model.Abstract;
using GameCampaignTutorial.Service.Abstract;
using MernisService;
using System;
using System.Threading.Tasks;

namespace GameCampaignTutorial.Service.Concrete
{
    public class MernisValidationService<T> : IValidationService<T> where T : IPerson
    {
        public async Task<bool?> Validate(T model)
        {
            try
            {
                KPSPublicSoapClient kPSPublicSoapClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);

                var result = await kPSPublicSoapClient.TCKimlikNoDogrulaAsync(Convert.ToInt64(model.IdentityNumber), model.Name, model.Surname, model.BirthDate.Year);
                return result?.Body?.TCKimlikNoDogrulaResult;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}