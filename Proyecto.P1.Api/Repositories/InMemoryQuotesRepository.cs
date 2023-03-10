using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryQuotesRepository: IQuotesRepository
{
    private readonly List<Quotes> _quotes;

    public InMemoryQuotesRepository()
    {
        _quotes = new List<Quotes>();
    }
    
    public async Task<Quotes> SaveAsync(Quotes quote)
    {
        quote.Id = _quotes.Count + 1;
        _quotes.Add(quote);
        
        return quote;
    }

    public async Task<Quotes> UpdateAsync(Quotes quote)
    {
        var index = _quotes.FindIndex(x => x.Id == quote.Id);

        if (index != -1)
            _quotes[index] = quote;
        return await Task.FromResult(quote);
    }

    public async Task<List<Quotes>> GetAllAsync()
    {
        return _quotes;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _quotes.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Quotes> GetById(int id)
    {
        var quote= _quotes.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(quote);
    }
}