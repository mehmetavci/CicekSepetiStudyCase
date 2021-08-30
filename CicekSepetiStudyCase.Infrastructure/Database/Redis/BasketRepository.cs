using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Domain.Repositories;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Infrastructure.Database.Redis
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
         
        /// <summary>
        /// Returns basket info based on 'Id' from Redis
        /// </summary>
        /// <param name="id">Basket Id</param>
        /// <returns></returns>
        public async Task<Basket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(data);
        }

        /// <summary>
        ///  Basket is created or updated with the sent key
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            var response = JsonSerializer.Serialize(basket);

            var created = await _database.StringSetAsync(basket.Id, response, TimeSpan.FromDays(7));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
         
        /// <summary>
        /// Deletes basked based on 'basketId' from Redis
        /// </summary>
        /// <param name="basketId">Basket Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }
    }
}
