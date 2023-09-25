using MediatR;
using AggregationApp.Domain.TodoItems;

namespace AggregationApp.Application.TodoItems.GetAllTodoItems;

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, List<ApartmentsResponse>>
{
    private readonly ITodoItemRepository _repository;

    public GetAllTodoItemsQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ApartmentsResponse>> Handle(GetAllTodoItemsQuery query, CancellationToken cancellationToken)
    {
        var todoItems = await _repository.GetAllAsync();

        return todoItems.Select(todoItem => new ApartmentsResponse
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
            Priority = todoItem.Priority
        }).ToList();
    }
}