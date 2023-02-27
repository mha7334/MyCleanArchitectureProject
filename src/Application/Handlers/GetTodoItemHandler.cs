using Application.Interfaces;
using Application.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItem>>
    {
        private readonly IRepository<TodoItem, int> _repository;

        public GetTodoItemsQueryHandler(IRepository<TodoItem, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();
            return items.ToList();
        }
    }

}
