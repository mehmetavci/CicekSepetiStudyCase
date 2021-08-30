using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Domain.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly IECommerceContext _context;
		private readonly IMongoCollection<T> _collection;
		public GenericRepository(IECommerceContext context)
		{
			_context = context;
			_collection = _context.GetCollection<T>(typeof(T).Name);
		}

		public async Task<T> GetByIdAsync(string id)
		{
			return await _collection.Find<T>(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _collection.Find<T>(Builders<T>.Filter.Empty).ToListAsync();
		} 
	}
}
