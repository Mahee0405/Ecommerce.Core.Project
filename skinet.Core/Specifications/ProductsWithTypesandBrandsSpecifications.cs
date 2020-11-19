using System;
using System.Linq.Expressions;
using skinet.Core.Entities;

namespace skinet.Core.Specifications
{
    public class ProductsWithTypesandBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductsWithTypesandBrandsSpecifications()
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }

        public ProductsWithTypesandBrandsSpecifications(int id) : base(x=>x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}
