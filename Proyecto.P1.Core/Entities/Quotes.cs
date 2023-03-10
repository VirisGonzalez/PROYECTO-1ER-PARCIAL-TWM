namespace Proyecto.P1.Core.Entities;

public class Quotes: EntityBase
{

    public int id_User { get; set; }
    public int id_Worker { get; set; }
    public int id_Service { get; set; }
    public DateTime DateTime { get; set; }
    public string Place { get; set; }
    public string Details { get; set; }
}