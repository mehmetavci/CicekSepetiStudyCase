using CicekSepetiStudyCase.Domain.Entities;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(string basketId);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
