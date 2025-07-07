using Domain;

namespace Application.Interfaces;
public interface IAppointmentRepository
{
    Task<Appointment> CreateAppointment(Appointment appointment, CancellationToken cancellationToken);
    Task<IEnumerable<Appointment>> GetPatientAppointments(Guid id, CancellationToken cancellationToken);
}
