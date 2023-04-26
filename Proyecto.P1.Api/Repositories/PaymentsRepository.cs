using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class PaymentsRepository : IPaymentsRepository
{
    private readonly IDbContext _dbContext;

    public PaymentsRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Payments> SaveAsync(Payments payment)
    {
        payment.Id = await _dbContext.Connection.InsertAsync(payment);
        return payment;
    }

    public async Task<Payments> UpdateAsync(Payments payment)
    {
        await _dbContext.Connection.UpdateAsync(payment);
        return payment;
    }

    public async Task<List<Payments>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Payments WHERE IsDeleted = 0";

        var payments = await _dbContext.Connection.QueryAsync<Payments>(sql);

        return payments.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var payments = await GetById(id);
        if (payments == null)
            return false;
        
        payments.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(payments);
    }

    public async Task<Payments> GetById(int id)
    {
        var payment = await _dbContext.Connection.GetAsync<Payments>(id);

        if (payment == null)
            return null;
        return payment.IsDeleted == true ? null : payment;
    }
}