using Macs.WebApi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Macs.WebApi.Endpoints.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetList")]
        public IEnumerable<Person> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Person
            {
                DateOfBirth = new DateTime(2000,11,18),
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