using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories.Interfaces;

public interface IUsersRepository
{
    //Metodo para guardar
    Task<Users> SaveAsync(Users user);
    
    //Metodo para Actucalizar 
    Task<Users> UpdateAsync(Users user);
    
    //Metodo para retornar una lista 
    Task<List<Users>> GetAllAsync();
    
    //Metodo para retornar el id que borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener  por id
    Task<Users> GetById(int id);
}