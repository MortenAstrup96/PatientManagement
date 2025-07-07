using Application.Interfaces;
using Domain;

namespace Application.Patients.CreatePatient;
public record CreatePatientCommand(string FullName, string Address, string Photo) : ICommand<Patient>;
