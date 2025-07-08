
namespace Domain;

/// <summary>
/// I would have liked to enforce more domain level rules here. Currently, for example
/// Dentists can technically be null, but that would not work with the domain logic. 
/// </summary>
public class Appointment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid PatientId { get; set; } 
    public string? Dentist { get; set; } 
    public AppointmentType AppointmentType { get; set; }
}
