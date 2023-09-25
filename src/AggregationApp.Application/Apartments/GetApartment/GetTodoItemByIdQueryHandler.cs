using MediatR;
using AggregationApp.Domain.TodoItems;

namespace AggregationApp.Application.TodoItems.GetTodoItem;

public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, ApartmentsResponse>
{
    private readonly ITodoItemRepository _repository;

    public GetTodoItemByIdQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ApartmentsResponse> Handle(GetTodoItemByIdQuery query, CancellationToken cancellationToken)
    {
        var todoItem = await _repository.GetByIdAsync(query.Id);
        if (todoItem == null) return null;

        return new ApartmentsResponse()
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
            Priority = todoItem.Priority 
        };
    }
}