using System;
namespace skinet.Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int prodItemId, string productName, string pictureUrl)
        {
            ProdItemId = prodItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProdItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

    }
}
