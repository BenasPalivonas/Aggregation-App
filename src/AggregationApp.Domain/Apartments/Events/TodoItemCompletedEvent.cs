using AggregationApp.Domain.Abstractions;

namespace AggregationApp.Domain.Apartments.Events;

public class ApartmentCompletedEvent : IDomainEvent
{
    public ApartmentCompletedEvent(Apartment item)
    {
        Apartment = item;
    }

    public Apartment Apartment { get; }
}
