using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IRequestsRepository
{
    //Metodo para guardar categorias
    Task<Requests> SaveAsync(Requests request);
    
    //Metodo para Actucalizar las categorias 
    Task<Requests> UpdateAsync(Requests request);
    
    //Metodo para retornar una lista de categorias
    Task<List<Requests>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Requests> GetById(int id);
}