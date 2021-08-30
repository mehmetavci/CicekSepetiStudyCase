using CicekSepetiStudyCase.Manager.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.Manager.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(string id);
        Task<ProductDto> CheckProductAvailability(BasketItemDto basketItem); 
        Task CheckProductUnitInStock(string productId, int quantity);
    }
}
