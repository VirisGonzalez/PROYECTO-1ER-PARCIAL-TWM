using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class QuotesRepository : IQuotesRepository
{
    private readonly IDbContext _dbContext;

    public QuotesRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Quotes> SaveAsync(Quotes quote)
    {
        quote.Id = await _dbContext.Connection.InsertAsync(quote);
        return quote;
    }

    public async Task<Quotes> UpdateAsync(Quotes quote)
    {
        await _dbContext.Connection.UpdateAsync(quote);
        return quote;
    }

    public async Task<List<Quotes>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Quotes WHERE IsDeleted = 0";

        var quotes = await _dbContext.Connection.QueryAsync<Quotes>(sql);

        return quotes.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var quotes = await GetById(id);
        if (quotes == null)
            return false;
        quotes.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(quotes);
    }

    public async Task<Quotes> GetById(int id)
    {
        var quote = await _dbContext.Connection.GetAsync<Quotes>(id);

        if (quote == null)
            return null;
        return quote.IsDeleted == true ? null : quote;
    }
}