using Macs.WebApi.Handlers.Services;
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
    public class PersonController(ILogger<PersonController> logger, IPersonHandler personHandler)
        : ControllerBase
    {
        private readonly ILogger<PersonController> _logger = logger;
        private readonly IPersonHandler personHandler = personHandler ?? throw new ArgumentNullException(nameof(personHandler));

        [HttpGet]
        [Route("persons", Name = "GetPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var people = await this.personHandler.GetList();
            return Ok(people);
        }

        [HttpGet]
        [Route("person/{id}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson(string id)
        {
            var people = await this.personHandler.GetPerson(id);
            return Ok(people);
        }

        [HttpGet]
        [Route("person-addresses", Name = "GetPersonAddresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Address>>> GetPersonAddresses(string id)
        {
            var addresses = await this.personHandler.GetAddresses(id);
            return Ok(addresses);
        }

    }
}