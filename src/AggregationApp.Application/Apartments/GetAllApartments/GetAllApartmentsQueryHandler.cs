using MediatR;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.Apartments.GetAllApartments;

public class GetAllApartmentsQueryHandler : IRequestHandler<GetAllApartmentsQuery, List<ApartmentResponse>>
{
    private readonly IApartmentRepository _repository;

    public GetAllApartmentsQueryHandler(IApartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ApartmentResponse>> Handle(GetAllApartmentsQuery query, CancellationToken cancellationToken)
    {
        var apartments = await _repository.GetAllAsync();

        return apartments.Select(apartment => new ApartmentResponse
        {
            Id = apartment.Id,
            Title = apartment.Title,
            DueDate = apartment.DueDate,
            IsCompleted = apartment.IsCompleted,
            Priority = apartment.Priority
        }).ToList();
    }
}