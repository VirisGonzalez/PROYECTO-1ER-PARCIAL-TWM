using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IQuotesRepository
{
    //Metodo para guardar categorias
    Task<Quotes> SaveAsync(Quotes quote);
    
    //Metodo para Actucalizar las categorias 
    Task<Quotes> UpdateAsync(Quotes quote);
    
    //Metodo para retornar una lista de categorias
    Task<List<Quotes>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Quotes> GetById(int id);
}