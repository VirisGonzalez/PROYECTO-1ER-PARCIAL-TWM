using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IWorkersRepository
{
    //Metodo para guardar categorias
    Task<Workers> SaveAsync(Workers worker);
    
    //Metodo para Actucalizar las categorias 
    Task<Workers> UpdateAsync(Workers worker);
    
    //Metodo para retornar una lista de categorias
    Task<List<Workers>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Workers> GetById(int id);
}