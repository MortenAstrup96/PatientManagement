
using Application.Interfaces;
using Application.Patients.CreatePatient;
using Application.Patients.GetAllPatients;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<CreatePatientCommand, Patient>, CreatePatientCommandHandler>();
        services.AddTransient<IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>>, GetAllPatientsQueryHandler>();
        return services;
    }
}
