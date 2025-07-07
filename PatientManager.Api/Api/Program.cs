using Api;
using Application;
using Infrastructure;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

Batteries.Init();
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure();
var app = builder.Build();

app.MapPatientEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.Run();