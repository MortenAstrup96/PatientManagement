namespace Application.Patients.GetPatientById;
using Application.Interfaces;
using Domain;

public record GetPatientByIdQuery(Guid Id) : IQuery<Patient>;
