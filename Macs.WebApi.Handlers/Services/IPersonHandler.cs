using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public interface IPersonHandler
    {
        Task<IEnumerable<Person>> GetListAsync();
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(string id);
        Task<Person> GetPersonAsync(string id);
        Task<IEnumerable<Address>> GetPersonAddressesAsync(string id);
        Task<Address> AddAddressAsync(Address address);
        Task<Address> GetAddressAsync(string id);
        Task<Address> UpdateAddressAsync(Address person);
        Task DeleteAddressAsync(string id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> GetContactAsync(string id);
        Task<IEnumerable<Contact>> GetPersonContactsAsync(string id);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(string id);
    }
}
