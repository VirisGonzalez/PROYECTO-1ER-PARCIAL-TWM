using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryServicesRepository: IServicesRepository
{
    private readonly List<Service> _services;

    public InMemoryServicesRepository()
    {
        _services = new List<Service>();
    }
    
    public async Task<Service> SaveAsync(Service service)
    {
        service.Id = _services.Count + 1;
        _services.Add(service);
        
        return service;
    }

    public async Task<Service> UpdateAsync(Service service)
    {
        var index = _services.FindIndex(x => x.Id == service.Id);

        if (index != -1)
            _services[index] = service;
        return await Task.FromResult(service);
    }

    public async Task<List<Service>> GetAllAsync()
    {
        return _services;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _services.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Service> GetById(int id)
    {
        var service= _services.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(service);
    }
}