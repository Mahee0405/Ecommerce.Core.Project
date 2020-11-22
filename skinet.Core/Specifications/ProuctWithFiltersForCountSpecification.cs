using System;
using skinet.Core.Entities;

namespace skinet.Core.Specifications
{
    public class ProuctWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProuctWithFiltersForCountSpecification(ProductSpecParams @params)
            : base(x =>
                 (string.IsNullOrEmpty(@params.Search) || x.Name.ToLower().Contains(@params.Search)) && 
                 (!@params.BrandId.HasValue || x.ProductBrandId == @params.BrandId) &&
                 (!@params.TypeId.HasValue || x.ProductTypeId == @params.TypeId)
            )
        {
        }
    }
}
