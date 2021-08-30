using AutoMapper;
using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Manager.Interfaces;
using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Domain.Repositories;
using CicekSepetiStudyCase.Shared.CustomExceptions;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CicekSepetiStudyCase.Shared.Extensions;

namespace CicekSepetiStudyCase.Manager.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns Product info based on 'Id' from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var product = await _productsRepository.GetByIdAsync(id);

            if (product.IsNull())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"The product was not found in the id sent: { id}");
            }

            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Returns product list from database
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var products = await _productsRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<ProductDto>>(products);
        }

        /// <summary>
        /// Check if product can be added to basket 
        /// </summary>
        /// <param name="basketItem"></param>
        /// <returns></returns>
        public async Task<ProductDto> CheckProductAvailability(BasketItemDto basketItem)
        {
            //checking product id
            var product = await _productsRepository.GetByIdAsync(basketItem.ProductId);

            if (product.IsNull())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"The product was not found in the id sent: { product.Id}");
            }
             
            await CheckProductUnitInStock(product.Id, basketItem.Quantity);
             
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Current stock control for the product added to the basket again
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task CheckProductUnitInStock(string productId, int quantity)
        {
            var product = await _productsRepository.GetByIdAsync(productId);
             
            if (quantity >= product.UnitInStock)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"There is not enough of this product in stock: {product.Id}");
            } 
        }


    }
}
