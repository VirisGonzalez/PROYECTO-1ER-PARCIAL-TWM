using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class PaymentsRepository : IPaymentsRepository
{
    public Task<Payments> SaveAsync(Payments payment)
    {
        throw new NotImplementedException();
    }

    public Task<Payments> UpdateAsync(Payments payment)
    {
        throw new NotImplementedException();
    }

    public Task<List<Payments>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Payments> GetById(int id)
    {
        throw new NotImplementedException();
    }
}