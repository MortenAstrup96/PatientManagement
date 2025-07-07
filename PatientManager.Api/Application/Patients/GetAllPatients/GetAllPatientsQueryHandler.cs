using Application.Interfaces;
using Domain;

namespace Application.Patients.GetAllPatients;
public class GetAllPatientsQueryHandler(IPatientRepository patientRepository) : IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery _, CancellationToken cancellationToken = default)
    {
        return await _patientRepository.GetAllPatients(cancellationToken);
    }
}