using Microsoft.AspNetCore.Identity;

namespace OnionCRM.Core.Domain;

public class AppUser : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }


}