using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using skinet.API.DTOs;
using skinet.Core.Entities;

namespace skinet.API.Helpers
{
    public class ProudctUrlResolver : IValueResolver<Product,ProductToReturnDTO,string>
    {
        private readonly IConfiguration _config;

        public ProudctUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }

        
    }
}
