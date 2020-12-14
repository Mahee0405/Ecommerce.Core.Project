using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using skinet.Core.Entities;
using skinet.Core.Entities.OrderAggregate;
using skinet.Core.Interface;
using skinet.Core.Specifications;


namespace skinet.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IBasketRepository _basketRepo;

        public OrderService(IUnitofWork unitofWork,
                            IBasketRepository basketRepo)
        {
            this._unitofWork = unitofWork;
            this._basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            //get items from Product Respo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitofWork.Repsository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            //get delvierymethod form repo
            var deliveryMethod = await _unitofWork.Repsository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            //calc subtotoal
            var subTotal = items.Sum(item => item.Price * item.Qunaity);

            //create order
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod,items, subTotal);


            _unitofWork.Repsository<Order>().Add(order);

            var result = await _unitofWork.Complete();

            if (result <= 0) return null;

            //delete basket

            await _basketRepo.DeleteBasketAsync(basketId);

            return order;

        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitofWork.Repsository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec= new skinet.Core.Specifications.OrdersWithItemAndOrderingSpecification(id, buyerEmail);
            return await _unitofWork.Repsository<Order>().GetEntityWithSpec(spec);

        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyersEmail)
        {
            var spec = new skinet.Core.Specifications.OrdersWithItemAndOrderingSpecification(buyersEmail);

            return await _unitofWork.Repsository<Order>().ListAsync(spec);

        }

        
    }
}
