
namespace Domain;
class Appointment
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid PatientId { get; set; } 
    public Guid DentistId { get; set; } 
}
