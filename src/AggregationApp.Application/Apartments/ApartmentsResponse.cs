namespace AggregationApp.Application.Apartments;

public class ApartmentsResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateOnly DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public string Priority { get; set; }
}