using Microsoft.AspNetCore.Identity;

namespace Blog_dotNetApi.Cors.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
