using Domain;

namespace Application.Interfaces;
public interface IPatientRepository
{
    Task<Patient> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Patient>> GetAllPatients(CancellationToken cancellationToken);
    Task<Patient> CreatePatientAsync(Patient patient, CancellationToken cancellationToken);
    Task<bool> DeletePatientAsync(Guid id, CancellationToken cancellationToken);
}
