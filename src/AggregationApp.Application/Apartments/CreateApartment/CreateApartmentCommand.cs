using MediatR;

namespace AggregationApp.Application.Apartments.CreateApartment;

public class CreateApartmentCommand : IRequest<int>
{
    public string Title { get; set; }
    public DateOnly DueDate { get; set; }
}
