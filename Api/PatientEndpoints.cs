namespace Api;

using Application.Interfaces;
using Application.Patients.CreatePatient;
using Application.Patients.DeletePatient;
using Application.Patients.GetAllPatients;
using Application.Patients.GetPatientById;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        group.MapDelete("{id}", async (
            [FromRoute] Guid id,
            [FromServices] ICommandHandler<DeletePatientCommand, bool> handler,
            CancellationToken ct) =>
        {
            var command = new DeletePatientCommand(id);
            var patients = await handler.Handle(command, ct);
            return Results.Ok(patients);
        });
        group.MapGet("", async (IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>> handler, CancellationToken ct) =>
        {
            var patients = await handler.Handle(new GetAllPatientsQuery(), ct);
            return Results.Ok(patients);
        });
        group.MapGet("{id}", async (
            [FromRoute] Guid id, 
            [FromServices] IQueryHandler<GetPatientByIdQuery, Patient> handler, 
            CancellationToken ct) =>
        {
            var query = new GetPatientByIdQuery(id);
            var patients = await handler.Handle(query, ct);
            return Results.Ok(patients);
        });
    }
}

