using FluentAssertions;
using Moq;
using AggregationApp.Domain.TodoItems;
using AggregationApp.Domain.TodoItems.Events;

namespace AggregationApp.Domain.UnitTests.TodoItems;

public class TodoItemTests
{
    [Fact]
    public void MarkAsCompleted_Should_Raise_TodoItemCompletedEvent()
    {
        // Arrange
        var todoItem = new TodoItem("Test", DateOnly.FromDateTime(DateTime.UtcNow), new PrioritySuggestionService());

        // Act
        todoItem.MarkAsCompleted();

        // Assert
        var todoItemCompletedEvent = todoItem.DomainEvents.OfType<TodoItemCompletedEvent>().SingleOrDefault();
        todoItemCompletedEvent.Should().NotBeNull();
        todoItemCompletedEvent!.TodoItem.Should().Be(todoItem);
    }
}