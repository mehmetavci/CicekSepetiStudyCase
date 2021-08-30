using CicekSepetiStudyCase.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Domain.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync(); 
    }
}
