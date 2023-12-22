using System.Data.SqlClient;
using Macs.WebApi.Models.Entities;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> Search(string searchTerm);
    }
}
