using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class ServiceServices : IServiceServices
{
    private readonly IServicesRepository _servicesRepository;

    public ServiceServices(IServicesRepository servicesRepository)
    {
        _servicesRepository = servicesRepository;
    }
    
    public async Task<ServiceDto> SaveAsync(ServiceDto serviceDto)
    {
        var service = new Service
        {
            tipo = serviceDto.tipo,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        service = await _servicesRepository.SaveAsync(service);
        service.Id = service.Id;
        return serviceDto;
    }

    public async Task<ServiceDto> UpdateAsync(ServiceDto serviceDto)
    {
        var service = await _servicesRepository.GetById(serviceDto.Id);

        if (service == null)
            throw new Exception("Service not found");
        service.tipo = serviceDto.tipo;
        service.UpdatedBy = "";
        service.UpdateDate = DateTime.Now;
        await _servicesRepository.UpdateAsync(service);

        return serviceDto;
    }

    public async Task<List<ServiceDto>> GetAllAsync()
    {
        var services = await _servicesRepository.GetAllAsync();
        var servicesDto =
            services.Select(s => new ServiceDto(s)).ToList();
        return servicesDto;
    }

    public async Task<bool> ServiceExist(int id)
    {
        var service = await _servicesRepository.GetById(id);
        return (service != null);
    }

    public async Task<ServiceDto> GetById(int id)
    {
        var service = await _servicesRepository.GetById(id);
        if (service == null)
            throw new Exception("Service Not Found");
        var serviceDto = new ServiceDto(service);
        return serviceDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _servicesRepository.DeleteAsync(id);
    }
}