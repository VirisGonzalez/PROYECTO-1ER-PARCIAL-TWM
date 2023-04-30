using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class RequestsRepository : IRequestsRepository
{
    private readonly IDbContext _dbContext;

    public RequestsRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Requests> SaveAsync(Requests request)
    {
        request.Id = await _dbContext.Connection.InsertAsync(request);
        return request;
    }

    public async Task<Requests> UpdateAsync(Requests request)
    {
        await _dbContext.Connection.UpdateAsync(request);
        return request;
    }

    public async Task<List<Requests>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Requests WHERE IsDeleted = 0";

        var request = await _dbContext.Connection.QueryAsync<Requests>(sql);

        return request.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var requests = await GetById(id);
        if (requests == null)
            return false;
        requests.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(requests);
    }

    public async Task<Requests> GetById(int id)
    {
        var request = await _dbContext.Connection.GetAsync<Requests>(id);

        if (request == null)
            return null;
        return request.IsDeleted == true ? null : request;
    }
}