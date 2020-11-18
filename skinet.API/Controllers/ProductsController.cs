using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skinet.Core.Entities;
using skinet.Core.Interface;

namespace skinet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _reposiotry;

        public ProductsController(IProductRepository reposiotry)
        {
            _reposiotry = reposiotry;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _reposiotry.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _reposiotry.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _reposiotry.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypess()
        {
            return Ok(await _reposiotry.GetProductTypesAsync());
        }
    }
}
