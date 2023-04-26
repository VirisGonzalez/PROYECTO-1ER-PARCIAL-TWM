using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Api.Services.Interfaces;
using Proyecto.P1.Core.Dto;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Services;

public class UserServices : IUserServices
{
    private readonly IUsersRepository _usersRepository;

    public UserServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        var user = new Users
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Phone = userDto.Phone,
            Password = userDto.Password,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        user = await _usersRepository.SaveAsync(user);
        user.Id = user.Id;
        return userDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        var user = await _usersRepository.GetById(userDto.Id);

        if (user == null)
            throw new Exception("User not found");
        user.Name = userDto.Name;
        user.Email = userDto.Email;
        user.Phone = userDto.Phone;
        user.Password = userDto.Password;
        user.UpdatedBy = "";
        user.UpdateDate = DateTime.Now;
        await _usersRepository.UpdateAsync(user);

        return userDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _usersRepository.GetAllAsync();
        var usersDto =
            users.Select(c => new UserDto(c)).ToList();
        return usersDto;
    }

    public async Task<bool> UserExist(int id)
    {
        var users = await _usersRepository.GetById(id);
        return (users != null);
    }

    public async Task<UserDto> GetById(int id)
    {
        var users = await _usersRepository.GetById(id);
        if (users == null)
            throw new Exception("User Category Not Found");
        var userDto = new UserDto(users);
        return userDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _usersRepository.DeleteAsync(id);
    }
}