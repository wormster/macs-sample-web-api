using Macs.WebApi.DataAccess.Repositories;
using Macs.WebApi.Models.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public class PersonHandler : IPersonHandler
    {
        private IPersonRepository personRepository;
        private IAddressRepository addressRepository;
        public PersonHandler(IPersonRepository personRepository, IAddressRepository addressRepository)
        {
            this.personRepository = personRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<IList<Person>> GetList()
        {
            var people = await personRepository.GetAllAsync();

            return people.ToList();

            //return Enumerable.Range(1, 5).Select(index => new Person
            //    {
            //        DateOfBirth = new DateTime(2000, 11, 18),
            //        FirstName = $"John{index}",
            //        MiddleName = "Stewart",
            //        LastName = $"Wormald{index}",
            //        Id = Guid.NewGuid(),
            //        Title = "Mr.",
            //    })
            //    .ToArray();
        }

        public async Task<Person> GetPerson(string id)
        {
            var person = await personRepository.GetByIdAsync(new Guid(id));

            return person;

        }

        public async Task<IList<Address>> GetAddresses(string id)
        {
            var addresses = await addressRepository.GetAddressesByPersonId(new Guid(id));

            return addresses.ToList();

        }
    }
}
