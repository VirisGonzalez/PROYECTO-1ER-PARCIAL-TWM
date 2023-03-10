using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestsController: ControllerBase
{
    private readonly IRequestsRepository _requestsRepository;
    
    public RequestsController(IRequestsRepository requestsRepository)
    {
        _requestsRepository = requestsRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Requests>>>> GetAll()
    {
        var request = await _requestsRepository.GetAllAsync();
        var response = new Response<List<Requests>>();
        response.Data = request;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Requests>>> Post([FromBody] Requests request)
    {
        request = await _requestsRepository.SaveAsync(request);
        
        var response = new Response<Requests>();
        response.Data = request;

        return Created($"/api/[controller]/{request.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Requests>>> GetById(int id)
    {
        var request = await _requestsRepository.GetById(id);
        var response = new Response<Requests>();
        response.Data = request;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Requests>>> Update([FromBody] Requests request)
    {
        var result = await _requestsRepository.UpdateAsync(request);
        var response = new Response<Requests> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var request = await _requestsRepository.DeleteAsync(id);

        return Ok(request);
    }
}