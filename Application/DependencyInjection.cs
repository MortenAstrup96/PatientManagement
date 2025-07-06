
using Application.Interfaces;
using Application.Patients.CreatePatient;
using Application.Patients.DeletePatient;
using Application.Patients.GetAllPatients;
using Application.Patients.GetPatientById;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<CreatePatientCommand, Patient>, CreatePatientCommandHandler>();
        services.AddTransient<ICommandHandler<DeletePatientCommand, bool>, DeletePatientCommandHandler>();
        services.AddTransient<IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>>, GetAllPatientsQueryHandler>();
        services.AddTransient<IQueryHandler<GetPatientByIdQuery, Patient>, GetPatientByIdQueryHandler>();
        return services;
    }
}
