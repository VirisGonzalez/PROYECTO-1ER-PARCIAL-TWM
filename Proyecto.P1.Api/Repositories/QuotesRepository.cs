using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class QuotesRepository : IQuotesRepository
{
    public Task<Quotes> SaveAsync(Quotes quote)
    {
        throw new NotImplementedException();
    }

    public Task<Quotes> UpdateAsync(Quotes quote)
    {
        throw new NotImplementedException();
    }

    public Task<List<Quotes>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Quotes> GetById(int id)
    {
        throw new NotImplementedException();
    }
}