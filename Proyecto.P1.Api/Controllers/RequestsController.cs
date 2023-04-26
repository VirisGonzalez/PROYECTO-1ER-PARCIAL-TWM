using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestsController: ControllerBase
{
    private readonly IRequestServices _requestServices;
    
    public RequestsController(IRequestServices requestServices)
    {
        _requestServices = requestServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<RequestDto>>>> GetAll()
    {
        var response = new Response<List<RequestDto>>
        {
            Data = await _requestServices.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<RequestDto>>> Post([FromBody] RequestDto requestDto)
    {
        var response = new Response<RequestDto>
        {
            Data = await _requestServices.SaveAsync(requestDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<RequestDto>>> GetById(int id)
    {
        var response = new Response<RequestDto>();
        
        if (!await _requestServices.RequestExist(id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }
        
        response.Data = await _requestServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<RequestDto>>> Update([FromBody] RequestDto requestDto)
    {
        var response = new Response<RequestDto>();
        
        if (!await _requestServices.RequestExist(requestDto.Id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }

        response.Data = await _requestServices.UpdateAsync(requestDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _requestServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}