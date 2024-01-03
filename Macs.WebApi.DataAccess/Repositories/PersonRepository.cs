using Macs.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository 
    {
        public PersonRepository(MacsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Person>> Search(string searchTerm)
        {
            return await FindByAsync(n => n.FirstName.Contains(searchTerm) || n.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Person> FindByKeyIncludeAddressesAndContacts(Guid id)
        {
            var person =  await dbSet.AsNoTracking()
                .Where(e => e.Id == id)
                .Include(a => a.Addresses)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync();

            return person;
        }
    }
}
