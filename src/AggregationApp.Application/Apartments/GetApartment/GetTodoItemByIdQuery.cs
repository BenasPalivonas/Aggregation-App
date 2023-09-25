using MediatR;

namespace AggregationApp.Application.TodoItems.GetTodoItem;

public class GetTodoItemByIdQuery : IRequest<ApartmentsResponse>
{
    public int Id { get; set; }
}