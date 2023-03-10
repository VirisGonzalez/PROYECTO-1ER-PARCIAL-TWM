using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController: ControllerBase
{
    private readonly IQuotesRepository _quotesRepository;
    
    public QuotesController(IQuotesRepository quotesRepository)
    {
        _quotesRepository = quotesRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Quotes>>>> GetAll()
    {
        var quotes = await _quotesRepository.GetAllAsync();
        var response = new Response<List<Quotes>>();
        response.Data = quotes;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Quotes>>> Post([FromBody] Quotes quote)
    {
        quote = await _quotesRepository.SaveAsync(quote);
        
        var response = new Response<Quotes>();
        response.Data = quote;

        return Created($"/api/[controller]/{quote.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Quotes>>> GetById(int id)
    {
        var quote = await _quotesRepository.GetById(id);
        var response = new Response<Quotes>();
        response.Data = quote;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Quotes>>> Update([FromBody] Quotes quote)
    {
        var result = await _quotesRepository.UpdateAsync(quote);
        var response = new Response<Quotes> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var quote = await _quotesRepository.DeleteAsync(id);

        return Ok(quote);
    }
}