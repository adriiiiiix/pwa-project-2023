using Microsoft.AspNetCore.Identity;

namespace PWA.Api.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
