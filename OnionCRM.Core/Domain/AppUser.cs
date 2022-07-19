using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnionCRM.Core.Domain;

public class AppUser : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Roleid { get; set; }

    //Add Relations
    [ForeignKey("Roleid")]
    public virtual Role Role { get; set; }
    
    


}