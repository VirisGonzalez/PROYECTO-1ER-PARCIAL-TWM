using Proyecto.P1.Core.Dto;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IUserServices
{
    //Metodo para guardar categorias
    Task<UserDto> SaveAsync(UserDto userDto);
    
    //Metodo para Actucalizar las categorias 
    Task<UserDto> UpdateAsync(UserDto userDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<UserDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> UserExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<UserDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}