using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IPaymentsRepository
{
    //Metodo para guardar categorias
    Task<Payments> SaveAsync(Payments payment);
    
    //Metodo para Actucalizar las categorias 
    Task<Payments> UpdateAsync(Payments payment);
    
    //Metodo para retornar una lista de categorias
    Task<List<Payments>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Payments> GetById(int id);
}