using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class ServiceDto : DtoBase
{
    public string tipo { get; set; }

    public ServiceDto()
    {
        
    }

    public ServiceDto(Service services)
    {
        Id = services.Id;
        tipo = services.tipo;
    }
}