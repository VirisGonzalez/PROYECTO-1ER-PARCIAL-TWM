using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class RequestDto : DtoBase
{
    public int id_User { get; set; }
    public int id_Service { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }

    public RequestDto()
    {
        
    }

    public RequestDto(Requests requests)
    {
        Id = requests.Id;
        id_User = requests.id_User;
        id_Service = requests.id_Service;
        Date = requests.Date;
        Details = requests.Details;
    }
}