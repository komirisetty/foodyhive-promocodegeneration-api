﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WellsFargo.Libraries.DataAccess.Interfaces;
using WellsFargo.Libraries.Models;
using WellsFargo.Libraries.ORM.Interfaces;

namespace WellsFargo.Libraries.DataAccess.Impl
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly IPromoCodeContext promoCodeContext = default(IPromoCodeContext);
        public PromoCodeRepository(IPromoCodeContext promoCodeContxt)
        {
            if (promoCodeContxt == default(IPromoCodeContext))

                throw new ArgumentNullException(nameof(promoCodeContxt));

            this.promoCodeContext = promoCodeContxt;
        }


        public PromoCodeModel CreateNewCampaign(PromoCodeModel addNewCampaign)
        {
            RandomCode generateRandomCode = new RandomCode();
            generateRandomCode.randomMethod(addNewCampaign);
            this.promoCodeContext._promoCode.InsertOne(addNewCampaign);
            return addNewCampaign;
        }

        public async Task<IEnumerable<PromoCodeModel>> GetPromoCodeByCampaign(string campaignName)
        {
            List<PromoCodeModel> promocodes = new List<PromoCodeModel>();
            var getPromocodes = await this.promoCodeContext._promoCode.FindAsync<PromoCodeModel>(f => f.CampaignName.ToLower().Contains(campaignName.ToLower()));           

            var campResults = await getPromocodes.ToListAsync();

            return campResults;
        }

        public async Task<IEnumerable<PromoCodeModel>> SearchCampaign(string campaign)
        {
            Expression<Func<PromoCodeModel, bool>> filter = p => p.CampaignName.ToLower().Contains(campaign.ToLower());

            var result = await this.promoCodeContext._promoCode.FindAsync<PromoCodeModel>(filter);

            var campResults = await result.ToListAsync();

            return campResults;     
        }

        public Task UpdateCampaign(PromoCodeModel existingCampaign)
        {
           
            FilterDefinition<PromoCodeModel> filter = Builders<PromoCodeModel>.Filter.Eq(m => m._id, existingCampaign._id);

            var updateCampaign = Builders<PromoCodeModel>.Update.Set("CampaignName", existingCampaign.CampaignName).
                Set("NoOfPromoCodes", existingCampaign.NoOfPromoCodes).
                Set("PromocodeCost", existingCampaign.PromocodeCost).
                Set("StartDate", existingCampaign.StartDate).
                Set("EndDate", existingCampaign.EndDate).
                Set("Prefix", existingCampaign.Prefix).
                Set("PromocodeGenerated", existingCampaign.PromocodeGenerated).
                Set("Remarks", existingCampaign.Remarks).
                Set("CampaignCreatedDate", existingCampaign.CampaignCreatedDate).
                Set("CreatedUserName", existingCampaign.CreatedUserName).
                Set("CampaignStatus", existingCampaign.CampaignStatus).
                Set("CancellaionResaon", existingCampaign.CancellaionResaon).
                Set("CancelledDate", existingCampaign.CancelledDate).
                Set("CancelledUser", existingCampaign.CancelledUser).
                Set("PortalPercentage", existingCampaign.PortalPercentage).
                Set("FranschisePercentage", existingCampaign.FranschisePercentage).
                Set("ChefPercentage", existingCampaign.ChefPercentage);

            var result = this.promoCodeContext._promoCode.FindOneAndUpdateAsync(filter, updateCampaign);

            return result;
        }

        public IEnumerable<PromoCodeModel> ViewCampaign()
        {
           var result =  this.promoCodeContext._promoCode.AsQueryable().ToList();

           var viewAllCapmaigns = result;

           return viewAllCapmaigns;           
        }
        
    }
}
