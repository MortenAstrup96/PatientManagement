using Application.Appointments.CreateAppointment;
using Application.Appointments.GetPatientAppointments;
using Application.Interfaces;
using Application.Patients.GetPatientById;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api;
public static class AppointmentEndpoints
{
    public static void MapAppointmentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/appointments");
        group.MapPost("", CreateAppointment).WithName(nameof(CreateAppointment));
        group.MapGet("{patientId}", GetPatientAppointments).WithName(nameof(GetPatientAppointments));
    }

    public static async Task<IResult> CreateAppointment(
        [FromBody] CreateAppointmentCommand command,
        [FromServices] ICommandHandler<CreateAppointmentCommand, Appointment> handler,
        CancellationToken ct)
    {
        var appointment = await handler.Handle(command, ct);
        return Results.Ok(appointment);
    }
    public static async Task<IResult> GetPatientAppointments(
        [FromRoute] Guid patientId,
        [FromServices] IQueryHandler<GetPatientAppointmentsQuery, IEnumerable<Appointment>> handler,
        CancellationToken ct)
    {
        var query = new GetPatientAppointmentsQuery(patientId);
        var appointments = await handler.Handle(query, ct);
        return Results.Ok(appointments);
    }
}

