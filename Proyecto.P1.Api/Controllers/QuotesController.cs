using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController: ControllerBase
{
    private readonly IQuoteServices _quoteServices;
    
    public QuotesController(IQuoteServices quoteServices)
    {
        _quoteServices = quoteServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<QuotesDto>>>> GetAll()
    {
        var response = new Response<List<QuotesDto>>
        {
            Data = await _quoteServices.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<QuotesDto>>> Post([FromBody] QuotesDto quotesDto)
    {
        var response = new Response<QuotesDto>
        {
            Data = await _quoteServices.SaveAsync(quotesDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<QuotesDto>>> GetById(int id)
    {
        var response = new Response<QuotesDto>();
        
        if (!await _quoteServices.QuoteExist(id))
        {
            response.Errors.Add("Quote Not Found");
            return NotFound(response);
        }
        
        response.Data = await _quoteServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<QuotesDto>>> Update([FromBody] QuotesDto quotesDto)
    {
        var response = new Response<QuotesDto>();
        
        if (!await _quoteServices.QuoteExist(quotesDto.Id))
        {
            response.Errors.Add("Quote Not Found");
            return NotFound(response);
        }

        response.Data = await _quoteServices.UpdateAsync(quotesDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _quoteServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}