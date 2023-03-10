using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryPaymentsRepository : IPaymentsRepository
{
    private readonly List<Payments> _payments;

    public InMemoryPaymentsRepository()
    {
        _payments = new List<Payments>();
    }
    
    public async Task<Payments> SaveAsync(Payments payment)
    {
        payment.Id = _payments.Count + 1;
        _payments.Add(payment);
        
        return payment;
    }

    public async Task<Payments> UpdateAsync(Payments payment)
    {
        var index = _payments.FindIndex(x => x.Id == payment.Id);

        if (index != -1)
            _payments[index] = payment;
        return await Task.FromResult(payment);
    }

    public async Task<List<Payments>> GetAllAsync()
    {
        return _payments;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _payments.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Payments> GetById(int id)
    {
        var payment= _payments.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(payment);
    }
}