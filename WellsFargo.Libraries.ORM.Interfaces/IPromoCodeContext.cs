using MongoDB.Driver;
using System;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.ORM.Interfaces
{
    public interface IPromoCodeContext
    {
        IMongoCollection<PromoCodeModel> _promoCode { get; }
    }
}
