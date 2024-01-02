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
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task DeletePersonAsync(string id);
        Task<Person> GetPersonAsync(string id);
        Task<IEnumerable<Address>> GetPersonAddressesAsync(string id);
    }
}
