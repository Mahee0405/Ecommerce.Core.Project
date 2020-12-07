using System;
using AutoMapper;
using skinet.API.DTOs;
using skinet.Core.Entities;
using skinet.Core.Entities.Identity;

namespace skinet.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProudctUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
