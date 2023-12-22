using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macs.WebApi.Models.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public interface IPersonHandler
    {
        Task<IList<Person>> GetList();
        Task<Person> GetPerson(string id);
        Task<IList<Address>> GetAddresses(string id);
    }
}
