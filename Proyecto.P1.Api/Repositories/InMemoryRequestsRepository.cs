using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryRequestsRepository: IRequestsRepository
{
    private readonly List<Requests> _requests;

    public InMemoryRequestsRepository()
    {
        _requests = new List<Requests>();
    }
    
    public async Task<Requests> SaveAsync(Requests request)
    {
        request.Id = _requests.Count + 1;
        _requests.Add(request);
        
        return request;
    }

    public async Task<Requests> UpdateAsync(Requests request)
    {
        var index = _requests.FindIndex(x => x.Id == request.Id);

        if (index != -1)
            _requests[index] = request;
        return await Task.FromResult(request);
    }

    public async Task<List<Requests>> GetAllAsync()
    {
        return _requests;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _requests.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Requests> GetById(int id)
    {
        var request= _requests.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(request);
    }
}