using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class WorkersRepository : IWorkersRepository
{
    public Task<Workers> SaveAsync(Workers worker)
    {
        throw new NotImplementedException();
    }

    public Task<Workers> UpdateAsync(Workers worker)
    {
        throw new NotImplementedException();
    }

    public Task<List<Workers>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Workers> GetById(int id)
    {
        throw new NotImplementedException();
    }
}