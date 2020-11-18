using System;
using Microsoft.AspNetCore.Mvc;

namespace skinet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController:ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "test";
        }
    }
}
