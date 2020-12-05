using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.DataAccess.Interfaces
{
    public interface IPromoCodeRepository
    {
        Task<IEnumerable<PromoCodeModel>> GetPromoCodeByCampaign(string campaignName);

        Task<IEnumerable<PromoCodeModel>> SearchCampaign(string campaign);

        IEnumerable<PromoCodeModel> ViewCampaign();

        public PromoCodeModel CreateNewCampaign(PromoCodeModel addNewCampaign);

        public Task UpdateCampaign(PromoCodeModel exixstingCampaign);
    }
}
