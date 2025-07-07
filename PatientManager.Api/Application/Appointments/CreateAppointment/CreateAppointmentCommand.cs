using Application.Interfaces;
using Domain;

namespace Application.Appointments.CreateAppointment;

public record CreateAppointmentCommand : ICommand<Appointment>
{
    public Guid PatientId { get; init; }
    public DateTime StartTime { get; init; }
    public TimeSpan Duration { get; init; }
    public string Dentist { get; init; }
    public AppointmentType AppointmentType { get; init; }
}
