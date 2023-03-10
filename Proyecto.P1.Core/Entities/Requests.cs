namespace Proyecto.P1.Core.Entities;

public class Requests: EntityBase
{
    //public int id { get; set; }
    public int id_User { get; set; }
    public int id_Service { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }
}