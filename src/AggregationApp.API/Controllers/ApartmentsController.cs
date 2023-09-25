using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AggregationApp.Application.TodoItems.CreateTodoItem;
using AggregationApp.Application.TodoItems.DeleteTodoItem;
using AggregationApp.Application.TodoItems.GetAllTodoItems;
using AggregationApp.Application.TodoItems.GetTodoItem;
using AggregationApp.Application.TodoItems.UpdateTodoItem;

namespace AggregationApp.API.Controllers
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateTodoItemCommand command)
        // {
        //     var result = await _mediator.Send(command);
        //     return CreatedAtAction(nameof(GetById), new { id = result }, command);
        // }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTodoItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTodoItemByIdQuery() { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoItemCommand command)
        // {
        //     if (id != command.Id)
        //     {
        //         return BadRequest();
        //     }

        //     var result = await _mediator.Send(command);
        //     if (result)
        //         return NoContent();

        //     return NotFound();
        // }

    }
}
