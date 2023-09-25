using MediatR;

namespace AggregationApp.Application.TodoItems.GetAllTodoItems;

public class GetAllTodoItemsQuery : IRequest<List<ApartmentsResponse>>
{
}