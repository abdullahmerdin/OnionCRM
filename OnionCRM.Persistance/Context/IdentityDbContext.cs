using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Core.Domain;

namespace OnionCRM.Persistance.Context;

public class IdentityDbContext : IdentityDbContext<AppUser, Role, int>
{


    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        

        //Maps
        builder.Entity<AppUser>()
            .HasMany(u => u.PhoneNumbers)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

    }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Role> Roles { get; set; }

}