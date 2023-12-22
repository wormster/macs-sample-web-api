using Macs.WebApi.Models.Entities;
using NPoco;

namespace Macs.WebApi.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository 
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Person>> Search(string searchTerm)
        {
            using (IDatabase db = Connection)
            {
                return await db.FetchAsync<Person>($"SELECT * FROM Person WHERE Name='{searchTerm}'");
            }
        }
        
    }
}
