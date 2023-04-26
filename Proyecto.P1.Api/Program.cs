using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.Repositories;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Api.Services;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.DataAccess;
using Proyecto.P1.Api.Services.Interfaces;

;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddScoped<IServiceServices, ServiceServices>();
builder.Services.AddScoped<IWorkerServices, WorkerServices>();
builder.Services.AddScoped<IQuoteServices, QuoteServices>();
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IQuotesRepository, QuotesRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IWorkersRepository, WorkersRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<IRequestsRepository, RequestsRepository>();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("Proyecto.P1.Core.Entities."))
        name = name.Replace("Proyecto.P1.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};


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