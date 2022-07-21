using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnionCRM.Core.Domain;

public class AppUser : IdentityUser<int>
{
    public DateTime BirthDate { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }

    public ICollection<PhoneNumber> PhoneNumbers { get; set; }





}