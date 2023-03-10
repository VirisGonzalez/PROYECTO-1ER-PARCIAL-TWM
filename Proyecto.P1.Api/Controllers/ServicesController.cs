using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController: ControllerBase
{
    private readonly IServicesRepository _servicesRepository;
    
    public ServicesController(IServicesRepository servicesRepository)
    {
        _servicesRepository = servicesRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Services>>>> GetAll()
    {
        var service = await _servicesRepository.GetAllAsync();
        var response = new Response<List<Services>>();
        response.Data = service;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Services>>> Post([FromBody] Services service)
    {
        service = await _servicesRepository.SaveAsync(service);
        
        var response = new Response<Services>();
        response.Data = service;

        return Created($"/api/[controller]/{service.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Services>>> GetById(int id)
    {
        var service = await _servicesRepository.GetById(id);
        var response = new Response<Services>();
        response.Data = service;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Services>>> Update([FromBody] Services service)
    {
        var result = await _servicesRepository.UpdateAsync(service);
        var response = new Response<Services> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var service = await _servicesRepository.DeleteAsync(id);

        return Ok(service);
    }
}