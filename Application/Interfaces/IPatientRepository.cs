using Domain;

namespace Application.Interfaces;
public interface IPatientRepository
{
    Task<Patient> GetPatientByIdAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<Patient>> GetAllPatients(CancellationToken cancellationToken);
    Task<Patient> CreatePatientAsync(Patient patient, CancellationToken cancellationToken);
    Task DeletePatientAsync(string id, CancellationToken cancellationToken);
}
