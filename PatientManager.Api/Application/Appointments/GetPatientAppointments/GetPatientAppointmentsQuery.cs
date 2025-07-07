using Application.Interfaces;
using Domain;

namespace Application.Appointments.GetPatientAppointments;
public class GetPatientAppointmentsQuery(Guid patientId) : IQuery<IEnumerable<Appointment>>
{
    public Guid PatientId { get; init; } = patientId;
}