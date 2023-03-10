using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class UsersRepository: IUsersRepository
{
    public Task<Users> SaveAsync(Users user)
    {
        throw new NotImplementedException();
    }

    public Task<Users> UpdateAsync(Users user)
    {
        throw new NotImplementedException();
    }

    public Task<List<Users>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Users> GetById(int id)
    {
        throw new NotImplementedException();
    }
}