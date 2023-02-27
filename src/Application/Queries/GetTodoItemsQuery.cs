using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetTodoItemsQuery : IRequest<List<TodoItem>>
    {
    }

}
