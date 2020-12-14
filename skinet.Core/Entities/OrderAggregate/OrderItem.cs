using System;
namespace skinet.Core.Entities.OrderAggregate
{
    public class OrderItem: BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int qunaity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Qunaity = qunaity;
      
        }

        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Qunaity { get; set; }
      

    }
}
