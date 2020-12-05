using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WellsFargo.Libraries.DataAccess.Interfaces;
using WellsFargo.Libraries.Domian.Interfaces;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.Domain.Impl
{
    public class PromoCodeDomainServices : IPromoCodeDoaminServices
    {
        private IPromoCodeRepository promoCodeRepository = default(IPromoCodeRepository);

        public PromoCodeDomainServices(IPromoCodeRepository promoCodeRepository)
        {
            if (promoCodeRepository == default(IPromoCodeRepository))
                throw new ArgumentNullException(nameof(promoCodeRepository));

            this.promoCodeRepository = promoCodeRepository;
        }
        public PromoCodeModel AddNewCampaign(PromoCodeModel promoCodeModel)
        {
            promoCodeModel = this.promoCodeRepository.CreateNewCampaign(promoCodeModel);

            return promoCodeModel;

        }

        public async Task<IEnumerable<PromoCodeModel>> GetPromoCodeByCampaign(string searchString)
        {
            var campaignByName = await this.promoCodeRepository.GetPromoCodeByCampaign(searchString);

            return campaignByName;
        }

        public async Task<IEnumerable<PromoCodeModel>> SearchCampaign(string name)
        {
            var searchCampaign = await this.promoCodeRepository.GetPromoCodeByCampaign(name);

            return searchCampaign;
        }

        public Task UpdateCampaign(PromoCodeModel existingCampaign)
        {
            var updateCampaign = this.promoCodeRepository.UpdateCampaign(existingCampaign);
            return updateCampaign;
        }

        public IEnumerable<PromoCodeModel> viewCampagin()
        {
            var viewAllCampagin = this.promoCodeRepository.ViewCampaign();

            return viewAllCampagin;        
        }
    }
}
