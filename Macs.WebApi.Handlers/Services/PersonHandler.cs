using Macs.WebApi.DataAccess.Repositories;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public class PersonHandler(IPersonRepository personRepository, IAddressRepository addressRepository,
            IContactRepository contactRepository)
        : IPersonHandler
    {
        public async Task<IEnumerable<Person>> GetListAsync()
        {
            var people = await personRepository.GetAllAsync();

            return people;
        }

        public async Task<IEnumerable<Person>> Search(string searchTerm)
        {
            var people = await personRepository.Search(searchTerm);

            return people;
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            var person = await personRepository.FindByKeyIncludeAddressesAndContacts(new Guid(id));

            return person;
        }

        public async Task<Person>AddPersonAsync(Person person)
        {
            var result = await personRepository.InsertAsync(person);
            await personRepository.SaveChangesAsync();

            return result;
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            personRepository.Update(person);
            await personRepository.SaveChangesAsync();

            return person;
        }

        public async Task DeletePersonAsync(string id)
        {
            await personRepository.DeleteAsync(new Guid(id));
            await personRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetPersonAddressesAsync(string id)
        {

            var person = await personRepository.FindByKeyIncludeAddressesAndContacts(new Guid(id));
            return person.Addresses;
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            var result = await addressRepository.InsertAsync(address);
            await addressRepository.SaveChangesAsync();

            return result;
        }

        public async Task<Address> GetAddressAsync(string id)
        {
            var address = await addressRepository.GetByIdAsync(new Guid(id));

            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            addressRepository.Update(address);
            await addressRepository.SaveChangesAsync();

            return address;
        }

        public async Task DeleteAddressAsync(string id)
        {
            await addressRepository.DeleteAsync(new Guid(id));
            await addressRepository.SaveChangesAsync();
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            var result = await contactRepository.InsertAsync(contact);
            await contactRepository.SaveChangesAsync();

            return result;
        }

        public async Task<Contact> GetContactAsync(string id)
        {
            var contact = await contactRepository.GetByIdAsync(new Guid(id));

            return contact;
        }

        public async Task<IEnumerable<Contact>> GetPersonContactsAsync(string id)
        {

            var person = await personRepository.FindByKeyIncludeAddressesAndContacts(new Guid(id));
            return person.Contacts;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            contactRepository.Update(contact);
            await contactRepository.SaveChangesAsync();

            return contact;
        }

        public async Task DeleteContactAsync(string id)
        {
            await contactRepository.DeleteAsync(new Guid(id));
            await contactRepository.SaveChangesAsync();
        }
    }
}
