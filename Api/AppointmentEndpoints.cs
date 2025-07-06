namespace Api;
public static class AppointmentEndpoints
{
    public static void MapAppointmentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/appointments");
        group.MapPost("", async (CancellationToken ct) =>
        {
            throw new NotImplementedException();
            return Results.Ok();
        });        
        group.MapGet("{patientId}", async (string patientId, CancellationToken ct) =>
        {
            throw new NotImplementedException();
            return Results.Ok();
        });
    }
}

