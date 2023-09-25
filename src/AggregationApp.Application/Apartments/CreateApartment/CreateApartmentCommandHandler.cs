using MediatR;
using AggregationApp.Domain.Abstractions;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.Apartments.CreateApartment;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, int>
{
    private readonly IApartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PrioritySuggestionService _priorityService;

    public CreateApartmentCommandHandler(IApartmentRepository repository, IUnitOfWork unitOfWork, PrioritySuggestionService priorityService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _priorityService = priorityService;
    }

    public async Task<int> Handle(CreateApartmentCommand command, CancellationToken cancellationToken)
    {
        var apartment = new Apartment(command.Title, command.DueDate, _priorityService);

        await _repository.AddAsync(apartment);
        _unitOfWork.Commit();

        return apartment.Id;
    }
}