using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class WorkersRepository : IWorkersRepository
{
    private readonly IDbContext _dbContext;

    public WorkersRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async  Task<Workers> SaveAsync(Workers worker)
    {
        worker.Id = await _dbContext.Connection.InsertAsync(worker);
        return worker;
    }

    public async  Task<Workers> UpdateAsync(Workers worker)
    {
        await _dbContext.Connection.UpdateAsync(worker);
        return worker;
    }

    public async Task<List<Workers>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Workers WHERE IsDeleted = 0";

        var worker = await _dbContext.Connection.QueryAsync<Workers>(sql);

        return worker.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var worker = await GetById(id);
        if (worker == null)
            return false;
        
        worker.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(worker); 
    }

    public async Task<Workers> GetById(int id)
    {
        var worker = await _dbContext.Connection.GetAsync<Workers>(id);

        if (worker == null)
            return null;
        return worker.IsDeleted == true ? null : worker;
    }
}