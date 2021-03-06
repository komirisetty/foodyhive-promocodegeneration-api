﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WellsFargo.Libraries.Domian.Interfaces;
using WellsFargo.Libraries.Models;
using WellsFargo.Libraries.Services.Interfaces;

namespace WellsFargo.Libraries.Services.Impl
{
    /// <summary>
    /// PromoCode API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController] 
    public class PromoCodeController : ControllerBase, IPromoCodeController
    {

        private IPromoCodeDoaminServices promoCodeService = default;

        /// <summary>
        /// Primary Constructor which depends on the PromoCode Domain Services
        /// </summary>
        /// <param name="promoCodeService"></param>

        public PromoCodeController(IPromoCodeDoaminServices promoCodeService)
        {

            if (promoCodeService == default(IPromoCodeDoaminServices))
                throw new ArgumentNullException(nameof(promoCodeService));

            this.promoCodeService = promoCodeService;
        }

        /// <summary>
        /// Adds a New Campaign to the Generate PromoCode DB.
        /// </summary>
        /// <param name="newPromoCodeModel">New Campaign Values</param>
        /// <returns>Added Campaign Record</returns>
        [HttpPost]
        [Route("createnewcampaign")]
        public IActionResult CreateNewCampaign([FromBody] PromoCodeModel newPromoCodeModel)
        {

            var addedCampaignRecord = this.promoCodeService.AddNewCampaign(newPromoCodeModel);
            return Ok(addedCampaignRecord);
        }

        /// <summary>
        /// Get PromoCodes List By Campaign Name
        /// </summary>
        /// <param name="campaignName">Campaign Name</param>
        /// <returns>Promo Codes</returns>
        [HttpGet]
        [Route("promocodedetails/{campaignName}")]
        public async Task<IActionResult> GetPromoCodeByCampaign(string campaignName)
        {
            var promoCodes = await this.promoCodeService.GetPromoCodeByCampaign(campaignName);

            return Ok(promoCodes);
        }


        /// <summary>
        /// Searchs Campaigns List by Campaign Name 
        /// </summary>
        /// <param name="searchString">Search String</param>
        /// <returns>Filtered Campaigns List</returns>

        [HttpGet]
        [Route("search/{searchString}")]
        public async Task<IActionResult> SearchCampaign(string searchString)
        {
            var filteredCampaignList = await this.promoCodeService.SearchCampaign(searchString);

            return Ok(filteredCampaignList);
        }

        /// <summary>
        /// Update the Existing Campaign Record
        /// </summary>
        /// <param name="updatePromoCodeModel">Updated Campaign Values</param>
        /// <returns>Updated Campaign Record</returns>
        [HttpPut]
        [Route("updatecampagain")]
        public IActionResult UpdateCampaign([FromBody] PromoCodeModel updatePromoCodeModel)
        {
            var updatedCampaignRecord = this.promoCodeService.UpdateCampaign(updatePromoCodeModel);

            return Ok(updatedCampaignRecord);
        }


        /// <summary>
        /// Gets Complete Campaign List
        /// </summary>
        /// <returns>Completed Campaigns List</returns>
        [HttpGet]
        [Route("")]
        public IActionResult ViewAllCampaigns()
        {
            var viewAllCampaigns = default(IEnumerable<PromoCodeModel>);
            var result = default(IActionResult);
            try
            {
                viewAllCampaigns = this.promoCodeService.viewCampagin();
                result = Ok(viewAllCampaigns);
            }
            catch(Exception exception)
            {
                throw exception;
            }                     

            return result;
        }
    }
}
//[EnableCors("CORS")]