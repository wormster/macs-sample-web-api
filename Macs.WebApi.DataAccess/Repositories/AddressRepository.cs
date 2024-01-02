using Macs.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository 
    {
        public AddressRepository(MacsContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Address>> GetAddressesByPersonId(Guid personId)
        {
            return await FindByAsync(a => a.PersonId == personId);
        }

        public async Task<Address> GetPreferredAddressForPerson(Guid personId)
        {
            var addresses =  await FindByAsync(a => a.PersonId == personId && a.Preferred == true);
            var preferredAddress = addresses.FirstOrDefault();
            return preferredAddress;
        }
        public async Task<Address> GetAddressByTypeForPerson(Guid personId, AddressType addressType)
        {
            var addresses = await FindByAsync(a => a.PersonId == personId && a.Type == addressType);
            var preferredAddress = addresses.FirstOrDefault();
            return preferredAddress;
        }
    }
}
