using Api;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Http.Json;
using SQLitePCL;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Batteries.Init();
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.MapPatientEndpoints();
app.MapAppointmentEndpoints();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.Run();