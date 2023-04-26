using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class QuoteServices : IQuoteServices
{
    private readonly IQuotesRepository _quotesRepository;

    public QuoteServices(IQuotesRepository quotesRepository)
    {
        _quotesRepository = quotesRepository;
    }

    public async Task<QuotesDto> SaveAsync(QuotesDto quotesDto)
    {
        var quote = new Quotes
        {
            id_User = quotesDto.id_User,
            id_Worker = quotesDto.id_Worker,
            id_Service = quotesDto.id_Service,
            DateTime = quotesDto.DateTime,
            Place = quotesDto.Place,
            Details = quotesDto.Details,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        quote = await _quotesRepository.SaveAsync(quote);
        quote.Id = quote.Id;
        return quotesDto;
    }

    public async Task<QuotesDto> UpdateAsync(QuotesDto quotesDto)
    {
        var quote = await _quotesRepository.GetById(quotesDto.Id);

        if (quote == null)
            throw new Exception("Quote not found");
        quote.id_User = quotesDto.id_User;
        quote.id_Worker = quotesDto.id_Worker;
        quote.id_Service = quotesDto.id_Service;
        quote.DateTime = quotesDto.DateTime;
        quote.Place = quotesDto.Place;
        quote.Details = quotesDto.Details;
        quote.UpdatedBy = "";
        quote.UpdateDate = DateTime.Now;
        await _quotesRepository.UpdateAsync(quote);

        return quotesDto;
    }

    public async Task<List<QuotesDto>> GetAllAsync()
    {
        var quotes = await _quotesRepository.GetAllAsync();
        var quotesDto =
            quotes.Select(q => new QuotesDto(q)).ToList();
        return quotesDto;
    }

    public async Task<bool> QuoteExist(int id)
    {
        var quotes = await _quotesRepository.GetById(id);
        return (quotes != null);
    }

    public async Task<QuotesDto> GetById(int id)
    {
        var quotes = await _quotesRepository.GetById(id);
        if (quotes == null)
            throw new Exception("Quote Category Not Found");
        var quoteDto = new QuotesDto(quotes);
        return quoteDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _quotesRepository.DeleteAsync(id);
    }
}