using Proyecto.P1.Core.Dto;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IWorkerServices
{
    //Metodo para guardar categorias
    Task<WorkerDto> SaveAsync(WorkerDto workerDto);
    
    //Metodo para Actucalizar las categorias 
    Task<WorkerDto> UpdateAsync(WorkerDto workerDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<WorkerDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> WorkerExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<WorkerDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}