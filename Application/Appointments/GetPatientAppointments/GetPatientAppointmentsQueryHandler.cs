using Application.Interfaces;
using Domain;

namespace Application.Appointments.GetPatientAppointments;
public class GetPatientAppointmentsQueryHandler(IAppointmentRepository appointmentRepository) : IQueryHandler<GetPatientAppointmentsQuery, IEnumerable<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<IEnumerable<Appointment>> Handle(GetPatientAppointmentsQuery query, CancellationToken cancellationToken = default)
    {
        return await _appointmentRepository.GetPatientAppointments(query.PatientId, cancellationToken);
    }
}