using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserServices _userServices;
    
    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userServices.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>
        {
            Data = await _userServices.SaveAsync(userDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id)
    {
        var response = new Response<UserDto>();
        
        if (!await _userServices.UserExist(id))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
        
        response.Data = await _userServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<UserDto>>> Update([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>();
        
        if (!await _userServices.UserExist(userDto.Id))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }

        response.Data = await _userServices.UpdateAsync(userDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _userServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}