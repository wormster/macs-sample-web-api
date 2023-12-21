using Macs.WebApi.Models.Entities;

namespace Macs.WebApi.Handlers.Services
{
    public class PersonHandler : IPersonHandler
    {
        public PersonHandler() { }


        public IList<Person> GetList()
        {
            //TODO: M.S. for J.W. - inject IPersonRepo and hook up with db here 
            return Enumerable.Range(1, 5).Select(index => new Person
                {
                    DateOfBirth = new DateTime(2000, 11, 18),
                    FirstName = $"John{index}",
                    MiddleName = "Stewart",
                    LastName = $"Wormald{index}",
                    Id = Guid.NewGuid(),
                    Title = "Mr.",
                })
                .ToArray();
        }
    }
}
