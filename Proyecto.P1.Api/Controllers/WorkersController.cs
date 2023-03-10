using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkersController: ControllerBase
{
    private readonly IWorkersRepository _workersRepository;
    
    public WorkersController(IWorkersRepository workersRepository)
    {
        _workersRepository = workersRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Workers>>>> GetAll()
    {
        var worker = await _workersRepository.GetAllAsync();
        var response = new Response<List<Workers>>();
        response.Data = worker;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Workers>>> Post([FromBody] Workers worker)
    {
        worker = await _workersRepository.SaveAsync(worker);
        
        var response = new Response<Workers>();
        response.Data = worker;

        return Created($"/api/[controller]/{worker.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Workers>>> GetById(int id)
    {
        var worker = await _workersRepository.GetById(id);
        var response = new Response<Workers>();
        response.Data = worker;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Workers>>> Update([FromBody] Workers worker)
    {
        var result = await _workersRepository.UpdateAsync(worker);
        var response = new Response<Workers> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var worker = await _workersRepository.DeleteAsync(id);

        return Ok(worker);
    }
}