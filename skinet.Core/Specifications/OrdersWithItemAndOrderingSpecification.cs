using System;
using skinet.Core.Entities.OrderAggregate;

namespace skinet.Core.Specifications
{
    public class OrdersWithItemAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemAndOrderingSpecification(string email) : base(o=>o.BuyerEmail == email)
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }


        public OrdersWithItemAndOrderingSpecification(int id ,string email) : base(o=>o.Id == id && o.BuyerEmail == email)
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }
    }
}



