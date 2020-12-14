using System;
using System.Linq;
using System.Security.Claims;

namespace skinet.API.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string RetriveEmailFormPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
