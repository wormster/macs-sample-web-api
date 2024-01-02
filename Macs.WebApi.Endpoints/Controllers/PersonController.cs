using Macs.WebApi.Handlers.Services;
using Macs.WebApi.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
            var people = await personHandler.GetListAsync();
            return Ok(people);
        }

        [HttpGet]
        [Route("person/{id}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var person = await personHandler.GetPersonAsync(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [Route("person", Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Person>> AddPerson([FromBody] Person person )
        {
            await personHandler.AddPerson(person);

            return CreatedAtAction("GetPerson",
                new { id = person.Id },
                person);
        }

        [HttpPut]
        [Route("person", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdatePerson([FromBody] Person person)
        {
            await personHandler.UpdatePersonAsync(person);

            return NoContent();
        }

        [HttpDelete]
        [Route("person/{id}", Name = "DeletePerson")]
        public async Task<ActionResult<Person>> DeletePerson(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            await personHandler.DeletePersonAsync(id);

            return NoContent(); // person == null? NotFound() : person;
        }

        [HttpGet]
        [Route("person-addresses", Name = "GetPersonAddresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Address>>> GetPersonAddresses(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var addresses = await personHandler.GetPersonAddressesAsync(id);
            return Ok(addresses);
        }

    }
}