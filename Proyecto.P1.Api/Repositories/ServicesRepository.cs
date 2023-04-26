using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class ServicesRepository : IServicesRepository
{
    private readonly IDbContext _dbContext;

    public ServicesRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Service> SaveAsync(Service service)
    {
        service.Id = await _dbContext.Connection.InsertAsync(service);
        return service;
    }

    public async Task<Service> UpdateAsync(Service service)
    {
        await _dbContext.Connection.UpdateAsync(service);
        return service;
    }

    public async Task<List<Service>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Service WHERE IsDeleted = 0";

        var services = await _dbContext.Connection.QueryAsync<Service>(sql);

        return services.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var service = await GetById(id);
        if (service == null)
            return false;
        service.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(service);
    }

    public async Task<Service> GetById(int id)
    {
        var service = await _dbContext.Connection.GetAsync<Service>(id);

        if (service == null)
            return null;
        return service.IsDeleted == true ? null : service;
    }
}