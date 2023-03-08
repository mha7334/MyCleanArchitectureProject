using Domain.Menu;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class MyCaDbContext : DbContext
{
    public MyCaDbContext(DbContextOptions<MyCaDbContext> options)
        : base(options)
    {

    }

    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyCaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}