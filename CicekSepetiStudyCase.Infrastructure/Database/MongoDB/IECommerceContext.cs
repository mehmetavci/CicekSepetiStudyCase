using MongoDB.Driver;
using System;

namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB
{
    public interface IECommerceContext : IDisposable
	{
		IMongoCollection<T> GetCollection<T>(string name);
	}
}
