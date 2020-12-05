using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.Services.Interfaces
{
    public interface IPromoCodeController
    {
        Task<IActionResult> GetPromoCodeByCampaign(string searchString);
        Task<IActionResult> SearchCampaign(string campaignName);
        IActionResult CreateNewCampaign(PromoCodeModel newPromoCodeModel);
        IActionResult UpdateCampaign(PromoCodeModel updatePromoCodeModel);
        IActionResult ViewAllCampaigns();

    }
}
