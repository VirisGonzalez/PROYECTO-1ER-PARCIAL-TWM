using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaymentsController: ControllerBase
{
    private readonly IPaymentsRepository _paymentsRepository;
    
    public PaymentsController(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Payments>>>> GetAll()
    {
        var payments = await _paymentsRepository.GetAllAsync();
        var response = new Response<List<Payments>>();
        response.Data = payments;

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Payments>>> Post([FromBody] Payments payment)
    {
        payment = await _paymentsRepository.SaveAsync(payment);
        
        var response = new Response<Payments>();
        response.Data = payment;

        return Created($"/api/[controller]/{payment.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Payments>>> GetById(int id)
    {
        var payment = await _paymentsRepository.GetById(id);
        var response = new Response<Payments>();
        response.Data = payment;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Payments>>> Update([FromBody] Payments payment)
    {
        var result = await _paymentsRepository.UpdateAsync(payment);
        var response = new Response<Payments> { Data = result };

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var payment = await _paymentsRepository.DeleteAsync(id);

        return Ok(payment);
    }
}