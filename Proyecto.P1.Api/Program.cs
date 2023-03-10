using Proyecto.P1.Api.Repositories;
using Proyecto.P1.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IUsersRepository, InMemoryUsersRepository>();
builder.Services.AddSingleton<IPaymentsRepository, InMemoryPaymentsRepository>();
builder.Services.AddSingleton<IRequestsRepository, InMemoryRequestsRepository>();
builder.Services.AddSingleton<IServicesRepository, InMemoryServicesRepository>();
builder.Services.AddSingleton<IWorkersRepository, InMemoryWorkersRepository>();
builder.Services.AddSingleton<IQuotesRepository, InMemoryQuotesRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();