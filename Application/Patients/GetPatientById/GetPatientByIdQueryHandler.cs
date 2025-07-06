using Application.Interfaces;
using Application.Patients.GetPatientById;
using Domain;

namespace Application.Patients.GetAllPatients;
public class GetPatientByIdQueryHandler(IPatientRepository patientRepository) : IQueryHandler<GetPatientByIdQuery, Patient>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Patient> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken = default)
    {
        return await _patientRepository.GetPatientByIdAsync(query.Id, cancellationToken);
    }
}