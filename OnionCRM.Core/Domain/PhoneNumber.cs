using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionCRM.Core.Domain;

public class PhoneNumber
{
    public int Id { get; set; }
    public string? Number { get; set; }
    public int UserId { get; set; }


    //Relations
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
}