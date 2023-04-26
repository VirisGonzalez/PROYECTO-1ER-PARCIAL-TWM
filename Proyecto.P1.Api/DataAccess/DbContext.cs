using System.Data.Common;
using MySqlConnector;

namespace Proyecto.P1.Api.DataAccess.Interfaces;

public class DbContext : IDbContext
{
    private readonly string _connectionString = 
        "server=localhost;user=root;password=Viris1108*;database=proyecto;port=3306";

    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}