using Macs.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(MacsContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Contact>> GetContactsByPersonId(Guid personId)
        {
            return await FindByAsync(c => c.PersonId == personId);
        }
        public async Task<Contact> GetPreferredContactForPerson(Guid personId)
        {
            var contacts = await FindByAsync(c => c.PersonId == personId && c.Preferred == true);
            var preferredContact = contacts.FirstOrDefault();
            return preferredContact;
        }
        public async Task<Contact> GetContactByTypeForPerson(Guid personId, ContactType contactType)
        {
            var contacts =  await FindByAsync(c => c.PersonId == personId && c.Type == contactType);
            var preferredContact = contacts.FirstOrDefault();

            return preferredContact;

        }
    }
}
