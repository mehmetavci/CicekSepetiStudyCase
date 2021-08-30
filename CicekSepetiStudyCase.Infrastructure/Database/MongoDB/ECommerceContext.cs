using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Infrastructure.Database.MongoDB.Settings;
using MongoDB.Driver;
using System;

namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB
{
    public class EcommerceContext : IECommerceContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IMongoClient _client = null;

        public EcommerceContext(IDatabaseSettings databaseSettings)
        {
            _client = new MongoClient(databaseSettings.ConnectionString);
            _database = _client.GetDatabase(databaseSettings.DatabaseName);

        }

        public IMongoCollection<Product> Products => GetCollection<Product>("products");

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
         
    }
}
