using AutoMapper;
using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Manager.Interfaces;
using CicekSepetiStudyCase.Domain.Entities;
using CicekSepetiStudyCase.Domain.Repositories;
using CicekSepetiStudyCase.Shared.CustomExceptions;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CicekSepetiStudyCase.Shared.Extensions;

namespace CicekSepetiStudyCase.Manager.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public BasketService(
            IBasketRepository basketRepository,
            IProductService productService,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns basket info based on 'Id' from Redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Basket> GetBasketByIdAsync(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return basket ?? throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"The basket was not found in the id sent: {id}");
        }

        /// <summary>
        ///  Adding product to basket
        /// </summary>
        /// <param name="basketDto"></param>
        /// <returns></returns>
        public async Task<Basket> AddProductToBasketAsync(BasketDto basketDto)
        {
            var product = await _productService.CheckProductAvailability(basketDto.Item);
            var basket = await _basketRepository.GetBasketAsync(basketDto.Id);

            //checking if there is a basket
            if (basket.IsNotNull())
            {
                //checking Check if this product has been added to the basket before
                var productInBasket = basket.Items.FirstOrDefault(x => x.Id == product.Id);


                if (productInBasket.IsNotNull())
                {
                    productInBasket.Quantity += basketDto.Item.Quantity;

                    //current stock control
                    await _productService.CheckProductUnitInStock(product.Id, productInBasket.Quantity);
                }
                else
                {
                    //add product to basket
                    basket.Items.Add(new BasketItem()
                    {

                        Id = product.Id,
                        Price = product.Price,
                        ProductName = product.Name,
                        Quantity = basketDto.Item.Quantity
                    });
                }
            }
            else
            {
                // create basket
                basket = _mapper.Map<Basket>(basketDto);
                //add product to basket
                basket.Items.Add(new BasketItem()
                {
                    Id = product.Id,
                    Price = product.Price,
                    ProductName = product.Name,
                    Quantity = basketDto.Item.Quantity
                });
            }

            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

            return updatedBasket;
        }

        /// <summary>
        /// Deletes basked based on 'id' from Redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBasketAsync(string id)
        {
            var basketDeleteControl = await _basketRepository.DeleteBasketAsync(id);

            if (!basketDeleteControl)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"The basket was not found in the id sent: {id}");
        }
         
    }
}
