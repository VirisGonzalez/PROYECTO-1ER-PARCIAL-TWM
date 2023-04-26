using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class WorkerServices : IWorkerServices
{
    private readonly IWorkersRepository _workersRepository;

    public WorkerServices(IWorkersRepository workersRepository)
    {
        _workersRepository = workersRepository;
    }
    
    public async Task<WorkerDto> SaveAsync(WorkerDto workerDto)
    {
        var worker = new Workers
        {
            Name = workerDto.Name,
            Skills = workerDto.Skills,
            Scores = workerDto.Scores,
            Availability = workerDto.Availability,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        worker = await _workersRepository.SaveAsync(worker);
        worker.Id = worker.Id;
        return workerDto;
    }

    public async Task<WorkerDto> UpdateAsync(WorkerDto workerDto)
    {
        var worker = await _workersRepository.GetById(workerDto.Id);

        if (worker == null)
            throw new Exception("Worker not found");
        worker.Name = workerDto.Name;
        worker.Skills = workerDto.Skills;
        worker.Scores = workerDto.Scores;
        worker.Availability = workerDto.Availability;
        worker.UpdatedBy = "";
        worker.UpdateDate = DateTime.Now;
        await _workersRepository.UpdateAsync(worker);

        return workerDto;
    }

    public async Task<List<WorkerDto>> GetAllAsync()
    {
        var workers = await _workersRepository.GetAllAsync();
        var workerDto =
            workers.Select(c => new WorkerDto(c)).ToList();
        return workerDto;
    }

    public async Task<bool> WorkerExist(int id)
    {
        var worker = await _workersRepository.GetById(id);
        return (worker != null);
    }

    public async Task<WorkerDto> GetById(int id)
    {
        var workers = await _workersRepository.GetById(id);
        if (workers == null)
            throw new Exception("Worker Category Not Found");
        var workerDto = new WorkerDto(workers);
        return workerDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _workersRepository.DeleteAsync(id);
    }
}