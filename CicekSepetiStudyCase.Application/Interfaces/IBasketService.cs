using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Domain.Entities;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Manager.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketByIdAsync(string id);
        Task<Basket> AddProductToBasketAsync(BasketDto basketDto); 
        Task DeleteBasketAsync(string id);
    }
}
