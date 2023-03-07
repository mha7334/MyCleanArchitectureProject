using Domain.Menu;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class MyCaDbContext : DbContext
{
    protected MyCaDbContext(DbContextOptions<MyCaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; }
}