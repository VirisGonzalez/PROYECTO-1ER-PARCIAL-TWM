using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IServicesRepository
{
    //Metodo para guardar categorias
    Task<Service> SaveAsync(Service service);
    
    //Metodo para Actucalizar las categorias 
    Task<Service> UpdateAsync(Service service);
    
    //Metodo para retornar una lista de categorias
    Task<List<Service>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Service> GetById(int id);
}