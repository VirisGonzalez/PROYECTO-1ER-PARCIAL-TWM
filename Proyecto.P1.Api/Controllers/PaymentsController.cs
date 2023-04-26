using Microsoft.AspNetCore.Mvc;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;
using Proyecto.P1.Core.Http;

namespace Proyecto.P1.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaymentsController: ControllerBase
{
    private readonly IPaymentServices _paymentServices;
    
    public PaymentsController(IPaymentServices paymentServices)
    {
        _paymentServices = paymentServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<PaymentDto>>>> GetAll()
    {
        var response = new Response<List<PaymentDto>>
        {
            Data = await _paymentServices.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<PaymentDto>>> Post([FromBody] PaymentDto paymentDto)
    {
        var response = new Response<PaymentDto>
        {
            Data = await _paymentServices.SaveAsync(paymentDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<PaymentDto>>> GetById(int id)
    {
        var response = new Response<PaymentDto>();

        if (!await _paymentServices.PaymentExist(id))
        {
            response.Errors.Add("Payment Not Found");
            return NotFound(response);
        }

        response.Data = await _paymentServices.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<PaymentDto>>> Update([FromBody] PaymentDto paymentDto)
    {
        var response = new Response<PaymentDto>();

        if (!await _paymentServices.PaymentExist(paymentDto.Id))
        {
            response.Errors.Add("Paymet Not Found");
            return NotFound(response);
        }

        response.Data = await _paymentServices.UpdateAsync(paymentDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _paymentServices.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}