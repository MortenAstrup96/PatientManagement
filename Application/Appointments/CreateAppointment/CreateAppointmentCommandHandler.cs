using Application.Interfaces;
using Domain;

namespace Application.Appointments.CreateAppointment;
public class CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository) : ICommandHandler<CreateAppointmentCommand, Appointment>
{
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<Appointment> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken = default)
    {
        var appointment = new Appointment
        {
            StartTime = command.StartTime,
            Duration = command.Duration,
            PatientId = command.PatientId,
            Dentist = command.Dentist,
            AppointmentType = command.AppointmentType

        };

        return await _appointmentRepository.CreateAppointment(appointment, cancellationToken);
    }
}