using Application.Contracts;
using Application.Services;
using Persistence.Contract;
using Persistence.Repositories;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

app.Run();