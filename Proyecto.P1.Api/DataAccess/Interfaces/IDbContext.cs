using System.Data.Common;

namespace Proyecto.P1.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}