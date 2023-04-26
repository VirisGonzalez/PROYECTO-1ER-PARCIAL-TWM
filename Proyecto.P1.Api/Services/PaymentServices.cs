using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class PaymentServices : IPaymentServices
{
    private readonly IPaymentsRepository _paymentsRepository;

    public PaymentServices(IPaymentsRepository paymentsRepository)
    {
        _paymentsRepository = paymentsRepository;
    }
    public async Task<PaymentDto> SaveAsync(PaymentDto paymentDto)
    {
        var payment = new Payments
        {
            id_User = paymentDto.id_User,
            id_Worker = paymentDto.id_Worker,
            id_Service = paymentDto.id_Service,
            Amount = paymentDto.Amount,
            Date = paymentDto.Date,
            Details = paymentDto.Details,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        payment = await _paymentsRepository.SaveAsync(payment);
        payment.Id = payment.Id;
        return paymentDto;
    }

    public async Task<PaymentDto> UpdateAsync(PaymentDto paymentDto)
    {
        var payment = await _paymentsRepository.GetById(paymentDto.Id);

        if (payment == null)
            throw new Exception("Payment not found");
        payment.id_User = paymentDto.id_User;
        payment.id_Worker = paymentDto.id_Worker;
        payment.id_Service = paymentDto.id_Service;
        payment.Amount = paymentDto.Amount;
        payment.Date = paymentDto.Date;
        payment.Details = paymentDto.Details;
        payment.UpdatedBy = "";
        payment.UpdateDate = DateTime.Now;
        await _paymentsRepository.UpdateAsync(payment);

        return paymentDto;
    }

    public async Task<List<PaymentDto>> GetAllAsync()
    {
        var payments = await _paymentsRepository.GetAllAsync();
        var paymentsDto =
            payments.Select(p => new PaymentDto(p)).ToList();
        return paymentsDto;
    }

    public async Task<bool> PaymentExist(int id)
    {
        var payment = await _paymentsRepository.GetById(id);
        return (payment != null);
    }

    public async Task<PaymentDto> GetById(int id)
    {
        var payment = await _paymentsRepository.GetById(id);
        if (payment == null)
            throw new Exception("Payment not found");
        var paymentDto = new PaymentDto(payment);
        return paymentDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _paymentsRepository.DeleteAsync(id);
    }
}