using Application.Interfaces;
using Domain;

namespace Application.Patients.DeletePatient;
public class DeletePatientCommandHandler(IPatientRepository patientRepository) : ICommandHandler<DeletePatientCommand, bool>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<bool> Handle(DeletePatientCommand command, CancellationToken cancellationToken = default)
    {
        return await _patientRepository.DeletePatientAsync(command.Id, cancellationToken);
    }
}