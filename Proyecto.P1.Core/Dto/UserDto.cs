using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Core.Dto;

public class UserDto : DtoBase
{
    public string Name { get; set; }
    public string Direction { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(Users users)
    {
        Id = users.Id;
        Name = users.Name;
        Direction = users.Direction;
        Email = users.Email;
        Phone = users.Phone;
    }
}