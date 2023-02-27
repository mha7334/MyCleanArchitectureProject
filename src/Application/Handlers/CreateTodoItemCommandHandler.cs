using Application.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IRepository<TodoItem, int> _repository;

        public CreateTodoItemCommandHandler(IRepository<TodoItem, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var item = new TodoItem { Title = request.Title };
            await _repository.AddAsync(item);
            return item.Id;
        }
    }

}
