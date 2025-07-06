using Application.Interfaces;
using Domain;

namespace Application.Patients.CreatePatient;
public record CreatePatientCommand(string name, string address) : ICommand<Patient>;
