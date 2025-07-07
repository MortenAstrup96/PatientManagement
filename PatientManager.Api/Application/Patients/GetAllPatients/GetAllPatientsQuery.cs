using Application.Interfaces;
using Domain;

namespace Application.Patients.GetAllPatients;
public record GetAllPatientsQuery() : IQuery<IEnumerable<Patient>>;
