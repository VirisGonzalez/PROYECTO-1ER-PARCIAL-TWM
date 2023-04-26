using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services.Interfaces;

public interface IPaymentServices
{
    //Metodo para guardar categorias
    Task<PaymentDto> SaveAsync(PaymentDto paymentDto);
    
    //Metodo para Actucalizar las categorias 
    Task<PaymentDto> UpdateAsync(PaymentDto paymentDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<PaymentDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrará
    Task<bool> PaymentExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<PaymentDto> GetById(int id);
    
    Task<bool> DeleteAsync(int id);
}