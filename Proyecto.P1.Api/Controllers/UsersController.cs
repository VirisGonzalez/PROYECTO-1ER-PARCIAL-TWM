using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    
    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Users>>>> GetAll()
    {
        var users = await _usersRepository.GetAllAsync();
        var response = new Response<List<Users>>();
        response.Data = users;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Users>>> Post([FromBody] Users user)
    {
        user = await _usersRepository.SaveAsync(user);
        
        var response = new Response<Users>();
        response.Data = user;

        return Created($"/api/[controller]/{user.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Users>>> GetById(int id)
    {
        var user = await _usersRepository.GetById(id);
        var response = new Response<Users>();
        response.Data = user;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Users>>> Update([FromBody] Users user)
    {
        var result = await _usersRepository.UpdateAsync(user);
        var response = new Response<Users> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var user = await _usersRepository.DeleteAsync(id);

        return Ok(user);
    }
}