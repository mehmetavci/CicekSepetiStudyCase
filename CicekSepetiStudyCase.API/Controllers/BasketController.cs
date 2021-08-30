using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Manager.Interfaces;
using CicekSepetiStudyCase.Domain.Entities; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CicekSepetiStudyCase.API.Controllers
{
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        /// <summary>
        /// Returns basket info based on 'Id' from Redis
        /// </summary>
        /// <param name="id">Basket Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Basket>> GetBasketById(string id)
        {
            var basket = await _basketService.GetBasketByIdAsync(id);

            return Ok(basket);
        }

        /// <summary>
        /// Adding product to basket
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        [HttpPost("product" )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Basket>> AddProductToBasketAsync(BasketDto basket)
        {
            var updatedBasket = await _basketService.AddProductToBasketAsync(basket);

            return CreatedAtAction(nameof(GetBasketById), new { id = updatedBasket.Id }, updatedBasket);
        }
         
        /// <summary>
        /// Deletes basked based on 'id' from Redis
        /// </summary>
        /// <param name="id">Basket Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBasketAsync(string id)
        {
            await _basketService.DeleteBasketAsync(id);

            return Ok();
        }
    }
}
