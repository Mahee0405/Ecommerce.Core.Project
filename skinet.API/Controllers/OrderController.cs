using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skinet.API.DTOs;
using skinet.API.Errors;
using skinet.API.Extensions;
using skinet.Core.Entities.OrderAggregate;
using skinet.Core.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skinet.API.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this._orderService = orderService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetriveEmailFormPrincipal();

            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem Creating Order"));

            return Ok(order);
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>>  GetordresforUser()
        {
            var email = HttpContext.User.RetriveEmailFormPrincipal();

            var orders = await _orderService.GetOrdersForUserAsync(email);

            var mappingResults = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders);

            return Ok(mappingResults);
            //return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdforUser(int id)
        {
            var email = HttpContext.User.RetriveEmailFormPrincipal();

            var order = await _orderService.GetOrderByIdAsync(id, email);

            if (order == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Order, OrderToReturnDto>(order);
            //return order;
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethpods()
        {
            return Ok(await _orderService.GetDeliveryMethodsAsync());
        }

    }
}
