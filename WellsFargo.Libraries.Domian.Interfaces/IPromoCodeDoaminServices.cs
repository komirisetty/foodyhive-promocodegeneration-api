using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.Domian.Interfaces
{
    public interface IPromoCodeDoaminServices
    {
        public PromoCodeModel AddNewCampaign(PromoCodeModel productsModel);

        Task<IEnumerable<PromoCodeModel>> GetPromoCodeByCampaign(string searchString);

        Task<IEnumerable<PromoCodeModel>> SearchCampaign(string name);

        IEnumerable<PromoCodeModel> viewCampagin();

        public Task UpdateCampaign(PromoCodeModel existingCampaign);
    }
}
