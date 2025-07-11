﻿
using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<SQLiteDatabase>();
        services.AddTransient<IPatientRepository, PatientRepository>();
        services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        return services;
    }
}
