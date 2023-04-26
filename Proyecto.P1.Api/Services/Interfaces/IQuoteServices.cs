using Proyecto.P1.Core.Dto;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IQuoteServices
{
    //Metodo para guardar categorias
    Task<QuotesDto> SaveAsync(QuotesDto quotesDto);
    
    //Metodo para Actucalizar las categorias 
    Task<QuotesDto> UpdateAsync(QuotesDto quotesDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<QuotesDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> QuoteExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<QuotesDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}