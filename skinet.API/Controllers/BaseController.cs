using System;
using Microsoft.AspNetCore.Mvc;

namespace skinet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController :ControllerBase
    {
        public BaseController()
        {
        }
    }
}
