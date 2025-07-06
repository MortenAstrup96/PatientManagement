using Application.Interfaces;
using Domain;

namespace Application.Patients.CreatePatient;
public record CreatePatientCommand(string Name, string Address) : ICommand<Patient>;
