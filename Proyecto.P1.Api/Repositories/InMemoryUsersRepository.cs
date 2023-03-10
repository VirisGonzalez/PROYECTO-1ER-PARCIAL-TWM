using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class InMemoryUsersRepository: IUsersRepository
{
    private readonly List<Users> _users;

    public InMemoryUsersRepository()
    {
        _users = new List<Users>();
    }
    
    public async Task<Users> SaveAsync(Users user)
    {
        user.Id = _users.Count + 1;
        _users.Add(user);
        
        return user;
    }

    public async Task<Users> UpdateAsync(Users user)
    {
        var index = _users.FindIndex(x => x.Id == user.Id);

        if (index != -1)
            _users[index] = user;
        return await Task.FromResult(user);
    }

    public async Task<List<Users>> GetAllAsync()
    {
        return _users;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _users.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Users> GetById(int id)
    {
        var user= _users.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(user);
    }
}