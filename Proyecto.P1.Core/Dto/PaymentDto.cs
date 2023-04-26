using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class PaymentDto : DtoBase
{
    public int id_User { get; set; }
    public int id_Worker { get; set; }
    public int id_Service { get; set; }
    public string Amount { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }

    public PaymentDto()
    {
        
    }

    public PaymentDto(Payments payments)
    {
        Id = payments.Id;
        id_User = payments.id_User;
        id_Worker = payments.id_Worker;
        id_Service = payments.id_Service;
        Amount = payments.Amount;
        Date = payments.Date;
        Details = payments.Details;

    }
}