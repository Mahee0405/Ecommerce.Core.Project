using System;
using skinet.Core.Entities.Identity;

namespace skinet.Core.Interface
{
    public interface ITokenService
    {
        string CreteToken(AppUser appUser);
    }
}
