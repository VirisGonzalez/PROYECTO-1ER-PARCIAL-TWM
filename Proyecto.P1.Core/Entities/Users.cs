﻿namespace Proyecto.P1.Core.Entities;

public class Users : EntityBase
{
    //public int id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; } 
    
    public string Password {get; set;}
    
}