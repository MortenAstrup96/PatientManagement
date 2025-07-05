using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure();
var app = builder.Build();


app.MapGet("/patients", (CancellationToken ct) =>
{
    var patient = "Patient1";
    return patient is null ? Results.NotFound() : Results.Ok(patient);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.Run();