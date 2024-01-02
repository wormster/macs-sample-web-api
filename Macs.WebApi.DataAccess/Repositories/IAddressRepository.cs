using System.Data.SqlClient;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByPersonId(Guid personId);
        Task<Address> GetPreferredAddressForPerson(Guid personId);
        Task<Address> GetAddressByTypeForPerson(Guid personId, AddressType addressType);
    }
}
