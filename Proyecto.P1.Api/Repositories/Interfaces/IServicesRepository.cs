using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IServicesRepository
{
    //Metodo para guardar categorias
    Task<Services> SaveAsync(Services service);
    
    //Metodo para Actucalizar las categorias 
    Task<Services> UpdateAsync(Services service);
    
    //Metodo para retornar una lista de categorias
    Task<List<Services>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Services> GetById(int id);
}