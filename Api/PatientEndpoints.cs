namespace Api;

using Application.Interfaces;
using Application.Patients.CreatePatient;
using Application.Patients.GetAllPatients;
using Domain;
using Microsoft.AspNetCore.Mvc;

public static class PatientEndpoints
{
    public static void MapPatientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/patients");
        group.MapPost("", async ([FromBody] CreatePatientCommand command, ICommandHandler<CreatePatientCommand, Patient> handler, CancellationToken ct) =>
        {
            var patient = await handler.Handle(command, ct);
            return Results.Ok(patient);
        });        
        group.MapGet("", async (IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>> handler, CancellationToken ct) =>
        {
            var patients = await handler.Handle(new GetAllPatientsQuery(), ct);
            return Results.Ok(patients);
        });        
        group.MapGet("{id}", async (string id, CancellationToken ct) =>
        {
            throw new NotImplementedException();
            return Results.Ok();
        });
    }
}

