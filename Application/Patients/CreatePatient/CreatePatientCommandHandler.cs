using Application.Interfaces;
using Domain;

namespace Application.Patients.CreatePatient;
public class CreatePatientCommandHandler(IPatientRepository patientRepository) : ICommandHandler<CreatePatientCommand, Patient>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Patient> Handle(CreatePatientCommand command, CancellationToken cancellationToken = default)
    {
        return await _patientRepository.CreatePatientAsync(new Patient(command.name, command.address), cancellationToken);
    }
}