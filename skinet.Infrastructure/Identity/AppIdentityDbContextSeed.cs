using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using skinet.Core.Entities.Identity;

namespace skinet.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
       public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Mahee",
                    Email = "mahee@test.com",
                    UserName = "mahee@test.com",
                    Address = new Address
                    {
                        FirstName = "Mahendra",
                        LastName = "Sahoo",
                        Street= "River Residency Ph 3",
                        City= "Pune",
                        State ="Maharastra",
                        Zipcode= "412114"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
