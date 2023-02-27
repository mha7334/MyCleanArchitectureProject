using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            var query = new GetTodoItemsQuery();
            var items = await _mediator.Send(query);
            return items;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTodoItem(CreateTodoItemCommand command)
        {
            var id = await _mediator.Send(command);
            return id;
        }
    }
}
