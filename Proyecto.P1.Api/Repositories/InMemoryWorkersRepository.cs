using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryWorkersRepository: IWorkersRepository
{
    private readonly List<Workers> _workers;

    public InMemoryWorkersRepository()
    {
        _workers = new List<Workers>();
    }
    
    public async Task<Workers> SaveAsync(Workers worker)
    {
        worker.Id = _workers.Count + 1;
        _workers.Add(worker);
        
        return worker;
    }

    public async Task<Workers> UpdateAsync(Workers worker)
    {
        var index = _workers.FindIndex(x => x.Id == worker.Id);

        if (index != -1)
            _workers[index] = worker;
        return await Task.FromResult(worker);
    }

    public async Task<List<Workers>> GetAllAsync()
    {
        return _workers;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _workers.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Workers> GetById(int id)
    {
        var worker= _workers.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(worker);
    }
}