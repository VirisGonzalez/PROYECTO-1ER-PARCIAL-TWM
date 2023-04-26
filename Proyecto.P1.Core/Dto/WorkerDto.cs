using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class WorkerDto : DtoBase
{
    public string Name { get; set; }
    public string Skills { get; set; }
    public string Scores { get; set; }
    public string Availability { get; set; }

    public WorkerDto()
    {
        
    }

    public WorkerDto(Workers workers)
    {
        Id = workers.Id;
        Name = workers.Name;
        Skills = workers.Skills;
        Scores = workers.Scores;
        Availability = workers.Availability;
    }
}