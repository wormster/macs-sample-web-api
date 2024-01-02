using System.Data.SqlClient;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.DataAccess.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactsByPersonId(Guid personId);
        Task<Contact> GetPreferredContactForPerson(Guid personId);
        Task<Contact> GetContactByTypeForPerson(Guid personId, ContactType contactType);
    }
}
