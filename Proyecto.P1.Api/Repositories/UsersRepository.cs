using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.P1.Api.DataAccess.Interfaces;
using Proyecto.P1.Api.Repositories.Interfaces;
using Proyecto.P1.Core.Entities;

namespace Proyecto.P1.Api.Repositories;

public class UsersRepository: IUsersRepository
{
    private readonly IDbContext _dbContext;

    public UsersRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Users> SaveAsync(Users user)
    {
        user.Id = await _dbContext.Connection.InsertAsync(user);
        return user;
    }

    public async Task<Users> UpdateAsync(Users user)
    {
        await _dbContext.Connection.UpdateAsync(user);
        return user;
    }

    public async Task<List<Users>> GetAllAsync()
    {
        const string sql = "SELECT * FROM User WHERE IsDeleted = 0";

        var users = await _dbContext.Connection.QueryAsync<Users>(sql);

        return users.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetById(id);
        if (user == null)
            return false;
        
        user.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(user); 
    }

    public async Task<Users> GetById(int id)
    {
        var user = await _dbContext.Connection.GetAsync<Users>(id);

        if (user == null)
            return null;
        return user.IsDeleted == true ? null : user;
    }
}