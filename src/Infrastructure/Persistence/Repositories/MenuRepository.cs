using Application.Common.Interfaces.Persistence;

using Domain.Menu;

namespace Infrastructure.Persistence.Repositories;
public class MenuRepository : IMenuRepository
{
    private readonly MyCaDbContext _dbContext;

    public MenuRepository(MyCaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}