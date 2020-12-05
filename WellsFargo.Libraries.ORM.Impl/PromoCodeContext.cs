using MongoDB.Driver;
using System;
using WellsFargo.Libraries.Models;
using WellsFargo.Libraries.ORM.Interfaces;

namespace WellsFargo.Libraries.ORM.Impl
{
    public class PromoCodeContext : IPromoCodeContext
    {
        private IMongoCollection<PromoCodeModel> promoCodeReview = default(IMongoCollection<PromoCodeModel>);
        private IDatabaseSettings databaseSettings = default(IDatabaseSettings);
        

        public PromoCodeContext(IDatabaseSettings promoCodeDatabaseSettings)
        {
            if (promoCodeDatabaseSettings == default(IDatabaseSettings))
            {
                throw new ArgumentNullException(nameof(promoCodeDatabaseSettings));
            }
            this.databaseSettings = promoCodeDatabaseSettings;

            var mongoClient = new MongoClient(this.databaseSettings.ConnectionString);
            var database = mongoClient.GetDatabase(this.databaseSettings.DatabaseName);
            this.promoCodeReview = database.GetCollection<PromoCodeModel>(this.databaseSettings.CollectionName);
        }
        public IMongoCollection<PromoCodeModel> _promoCode { 

            get { 
                return this.promoCodeReview;
            }
        }

      
    }
}
