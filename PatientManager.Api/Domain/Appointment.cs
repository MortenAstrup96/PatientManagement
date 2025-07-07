
namespace Domain;
public class Appointment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid PatientId { get; set; } 
    public string? Dentist { get; set; } 
    public AppointmentType AppointmentType { get; set; }
}
