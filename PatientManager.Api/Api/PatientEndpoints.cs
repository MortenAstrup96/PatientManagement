namespace Api;

using Api.Dto;
using Application.Interfaces;
using Application.Patients.CreatePatient;
using Application.Patients.DeletePatient;
using Application.Patients.GetAllPatients;
using Application.Patients.GetPatientById;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// Patient Endpoints using Minimal APIs
/// </summary>
public static class PatientEndpoints
{
    public static void MapPatientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/patients");
        group.MapPost("", CreatePatient).WithName(nameof(CreatePatient));
        group.MapGet("", GetAllPatients).WithName(nameof(GetAllPatients));
        group.MapGet("{id}", GetPatientById).WithName(nameof(GetPatientById));
        group.MapDelete("{id}", DeletePatient).WithName(nameof(DeletePatient));
    }

    public static async Task<IResult> CreatePatient(
        [FromBody] CreatePatientCommand command,
        [FromServices] ICommandHandler<CreatePatientCommand, Patient> handler,
        CancellationToken ct)
    {
        var patient = await handler.Handle(command, ct);

        var patientResponse = new PatientResponse(
            patient.Id,
            patient.FullName,
            patient.Address,
            "data:image/jpeg;base64," + Convert.ToBase64String(patient.Photo));
        return Results.Ok(patientResponse);
    }

    public static async Task<IResult> DeletePatient(
        [FromRoute] Guid id,
        [FromServices] ICommandHandler<DeletePatientCommand, bool> handler,
        CancellationToken ct)
    {
        var command = new DeletePatientCommand(id);
        var result = await handler.Handle(command, ct);
        return result ? Results.NoContent() : Results.NotFound();
    }

    public static async Task<IResult> GetAllPatients(
        [FromServices] IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>> handler,
        CancellationToken ct)
    {
        var patients = await handler.Handle(new GetAllPatientsQuery(), ct);
        return Results.Ok(patients);
    }

    public static async Task<IResult> GetPatientById(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetPatientByIdQuery, Patient> handler,
        CancellationToken ct)
    {
        var query = new GetPatientByIdQuery(id);
        var patient = await handler.Handle(query, ct);

        if (patient is null) return Results.NotFound();

        var patientResponse = new PatientResponse(
            patient.Id, 
            patient.FullName, 
            patient.Address,
            "data:image/jpeg;base64,"+Convert.ToBase64String(patient.Photo));
        return Results.Ok(patientResponse);
    }
}

