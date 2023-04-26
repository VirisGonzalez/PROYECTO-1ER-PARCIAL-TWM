using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkersController: ControllerBase
{
    private readonly IWorkerServices _workerServices;
    
    public WorkersController(IWorkerServices workerServices)
    {
        _workerServices = workerServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<WorkerDto>>>> GetAll()
    {
        var response = new Response<List<WorkerDto>>
        {
            Data = await _workerServices.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<WorkerDto>>> Post([FromBody] WorkerDto workerDto)
    {
        var response = new Response<WorkerDto>
        {
            Data = await _workerServices.SaveAsync(workerDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<WorkerDto>>> GetById(int id)
    {
        var response = new Response<WorkerDto>();
        
        if (!await _workerServices.WorkerExist(id))
        {
            response.Errors.Add("Worker Not Found");
            return NotFound(response);
        }
        
        response.Data = await _workerServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<WorkerDto>>> Update([FromBody] WorkerDto workerDto)
    {
        var response = new Response<WorkerDto>();
        
        if (!await _workerServices.WorkerExist(workerDto.Id))
        {
            response.Errors.Add("Worker Not Found");
            return NotFound(response);
        }

        response.Data = await _workerServices.UpdateAsync(workerDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _workerServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}