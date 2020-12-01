using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skinet.Core.Entities;
using skinet.Core.Interface;

namespace skinet.API.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<BasketItem>> GetBasketById(string id)
        {
            var basket = await _repository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var UpdateBasket = await _repository.UpdateBasketAsync(basket);
            return Ok(UpdateBasket);
        }


        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
             await _repository.DeleteBasketAsync(id);
        }

            

    }
}
