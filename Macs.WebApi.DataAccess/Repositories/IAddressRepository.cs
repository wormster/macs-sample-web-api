using System.Data.SqlClient;
using Macs.WebApi.Models.Entities;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByPersonId(Guid personId);
    }
}
