using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController: ControllerBase
{
    private readonly IServiceServices _serviceServices;
    
    public ServicesController(IServiceServices srServiceServices)
    {
        _serviceServices = srServiceServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ServiceDto>>>> GetAll()
    {
        var response = new Response<List<ServiceDto>>
        {
            Data = await _serviceServices.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ServiceDto>>> Post([FromBody] ServiceDto serviceDto)
    {
        var response = new Response<ServiceDto>
        {
            Data = await _serviceServices.SaveAsync(serviceDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ServiceDto>>> GetById(int id)
    {
        var response = new Response<ServiceDto>();
        
        if (!await _serviceServices.ServiceExist(id))
        {
            response.Errors.Add("Service Not Found");
            return NotFound(response);
        }
        
        response.Data = await _serviceServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ServiceDto>>> Update([FromBody] ServiceDto serviceDto)
    {
        var response = new Response<ServiceDto>();
        
        if (!await _serviceServices.ServiceExist(serviceDto.Id))
        {
            response.Errors.Add("Service Not Found");
            return NotFound(response);
        }

        response.Data = await _serviceServices.UpdateAsync(serviceDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _serviceServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}