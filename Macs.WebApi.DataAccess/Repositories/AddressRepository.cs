using Macs.WebApi.Models.Entities;
using NPoco;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository 
    {
        public AddressRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Address>> GetAddressesByPersonId(Guid personId)
        {
            using IDatabase db = Connection;
            return await db.FetchAsync<Address>($"SELECT * FROM Addresses WHERE PersonId='{personId}'");
        }
        
    }
}
