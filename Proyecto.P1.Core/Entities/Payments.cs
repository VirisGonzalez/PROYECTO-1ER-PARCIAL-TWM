namespace Proyecto.P1.Core.Entities;

public class Payments : EntityBase
{
    //public int id { get; set; }
    public int id_User { get; set; }
    public int id_Worker { get; set; }
    public int id_Service { get; set; }
    public string Amount { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }
}