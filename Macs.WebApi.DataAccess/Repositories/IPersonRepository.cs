using System.Data.SqlClient;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> Search(string searchTerm);
        Task<Person> FindByKeyIncludeAddresses(Guid id);
    }
}
