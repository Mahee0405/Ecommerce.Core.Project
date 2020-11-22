using System;
using System.Linq.Expressions;
using skinet.Core.Entities;

namespace skinet.Core.Specifications
{
    public class ProductsWithTypesandBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductsWithTypesandBrandsSpecifications(ProductSpecParams @params)
            :base(x=>
                (string.IsNullOrEmpty(@params.Search) || x.Name.ToLower().Contains(@params.Search)) &&
                (!@params.BrandId.HasValue || x.ProductBrandId == @params.BrandId) &&
                (!@params.TypeId.HasValue || x.ProductTypeId == @params.TypeId)
            )
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(@params.PageSize * (@params.PageIndex - 1), @params.PageSize);

            if(!string.IsNullOrEmpty(@params.Sort))
            {
                switch(@params.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;


                }
            }
        }

        public ProductsWithTypesandBrandsSpecifications(int id) : base(x=>x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}
