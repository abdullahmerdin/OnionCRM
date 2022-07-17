using Microsoft.EntityFrameworkCore;
using OnionCRM.Core.Domain;

namespace OnionCRM.Persistance.Context;

public class OnionProjectContext : DbContext
{
    public OnionProjectContext(DbContextOptions<OnionProjectContext> options) : base(options)
    {

    }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        
       
}