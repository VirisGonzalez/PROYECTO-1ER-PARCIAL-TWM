using Proyecto.P1.Core.Dto;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IServiceServices
{
    //Metodo para guardar categorias
    Task<ServiceDto> SaveAsync(ServiceDto serviceDto);
    
    //Metodo para Actucalizar las categorias 
    Task<ServiceDto> UpdateAsync(ServiceDto serviceDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<ServiceDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> ServiceExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<ServiceDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}