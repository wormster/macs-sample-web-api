using Macs.WebApi.DataAccess.Repositories;
using Macs.WebApi.DataAccess.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public class PersonHandler: IPersonHandler
    {
        private IPersonRepository personRepository;
        private IAddressRepository addressRepository;
        public PersonHandler(IPersonRepository personRepository, IAddressRepository addressRepository)
        {
            this.personRepository = personRepository;
            this.addressRepository = addressRepository;
        }

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

        public async Task<Person>AddPerson(Person person)
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
    }
}
