using Proyecto.P1.Core.Dto;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IRequestServices
{
    //Metodo para guardar categorias
    Task<RequestDto> SaveAsync(RequestDto requestDto);
    
    //Metodo para Actucalizar las categorias 
    Task<RequestDto> UpdateAsync(RequestDto requestDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<RequestDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> RequestExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<RequestDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}