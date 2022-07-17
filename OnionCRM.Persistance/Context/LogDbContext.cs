using Microsoft.EntityFrameworkCore;

namespace OnionCRM.Persistance.Context;

public class LogDbContext : DbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
    {

    }

}