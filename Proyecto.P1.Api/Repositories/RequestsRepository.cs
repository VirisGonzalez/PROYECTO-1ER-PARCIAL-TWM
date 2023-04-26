using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class RequestsRepository : IRequestsRepository
{
    public Task<Requests> SaveAsync(Requests request)
    {
        throw new NotImplementedException();
    }

    public Task<Requests> UpdateAsync(Requests request)
    {
        throw new NotImplementedException();
    }

    public Task<List<Requests>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Requests> GetById(int id)
    {
        throw new NotImplementedException();
    }
}