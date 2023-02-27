using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoItemRepository : IRepository<TodoItem, int>
    {
        private readonly DbContext _context;

        public TodoItemRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoItem item)
        {
            await _context.Set<TodoItem>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.Set<TodoItem>().ToListAsync();
        }

        public Task<TodoItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItem entity)
        {
            throw new NotImplementedException();
        }
    }

}
