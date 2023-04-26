using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class RequestServices : IRequestServices
{
    private readonly IRequestsRepository _requestsRepository;

    public RequestServices(IRequestsRepository requestsRepository)
    {
        _requestsRepository = requestsRepository;
    }
    
    public async Task<RequestDto> SaveAsync(RequestDto requestDto)
    {
        var request = new Requests()
        {
            id_User = requestDto.id_User,
            id_Service = requestDto.id_Service,
            Date = requestDto.Date,
            Details = requestDto.Details,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        request = await _requestsRepository.SaveAsync(request);
        request.Id = request.Id;
        return requestDto;
    }

    public async Task<RequestDto> UpdateAsync(RequestDto requestDto)
    {
        var request = await _requestsRepository.GetById(requestDto.Id);

        if (request == null)
            throw new Exception("Request not found");
        request.id_User = requestDto.id_User;
        request.id_Service = requestDto.id_Service;
        request.Date = requestDto.Date;
        request.Details = requestDto.Details;
        request.UpdatedBy = "";
        request.UpdateDate = DateTime.Now;
        await _requestsRepository.UpdateAsync(request);

        return requestDto;
    }

    public async Task<List<RequestDto>> GetAllAsync()
    {
        var requests = await _requestsRepository.GetAllAsync();
        var requestsDto =
            requests.Select(r => new RequestDto(r)).ToList();
        return requestsDto;
    }

    public async Task<bool> RequestExist(int id)
    {
        var request = await _requestsRepository.GetById(id);
        return (request != null);
    }

    public async Task<RequestDto> GetById(int id)
    {
        var requests = await _requestsRepository.GetById(id);
        if (requests == null)
            throw new Exception("Request Category Not Found");
        var requestDto = new RequestDto(requests);
        return requestDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _requestsRepository.DeleteAsync(id);
    }
}