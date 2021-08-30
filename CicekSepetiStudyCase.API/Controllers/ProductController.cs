using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiStudyCase.API.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns product list from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            return Ok(products);
        }

        /// <summary>
        /// Returns Product info based on 'Id' from database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            return Ok(product);
        }
    }
}
