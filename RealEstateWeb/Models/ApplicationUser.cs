using Microsoft.AspNetCore.Identity;

namespace RealEstateWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
