using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class QuotesDto : DtoBase
{
    public int id_User { get; set; }
    public int id_Worker { get; set; }
    public int id_Service { get; set; }
    public DateTime DateTime { get; set; }
    public string Place { get; set; }
    public string Details { get; set; }

    public QuotesDto()
    {
        
    }
    public QuotesDto(Quotes quotes)
    {
        Id = quotes.Id;
        id_User = quotes.id_User;
        id_Worker = quotes.id_Worker;
        id_Service = quotes.id_Service;
        DateTime = quotes.DateTime;
        Place = quotes.Place;
        Details = quotes.Details;
    }
}