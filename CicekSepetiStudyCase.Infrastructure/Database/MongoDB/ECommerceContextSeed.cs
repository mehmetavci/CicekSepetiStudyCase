using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Infrastructure.Database.MongoDB.SeedData;
using CicekSepetiStudyCase.Shared.Extensions;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB
{
    public class ECommerceContextSeed
    {
        public static async Task SeedAsync(IECommerceContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var productCollection = context.GetCollection<Product>(nameof(Product));

                //Check if the product has been added before
                if (!productCollection.Find(p => true).Any())
                {  
                    var products = ProductTestData.FillProductCollectionWithTestData();

                    if (products.IsNotNull() && products.Count > 0)
                    {
                        await productCollection.InsertManyAsync(products);
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ECommerceContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
