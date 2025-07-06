using Application.Interfaces;

namespace Application.Patients.DeletePatient;
public record DeletePatientCommand(Guid Id) : ICommand<bool>;
