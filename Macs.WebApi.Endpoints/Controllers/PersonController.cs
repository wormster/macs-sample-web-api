using Macs.WebApi.Handlers.Services;
using Macs.WebApi.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Net;

namespace Macs.WebApi.Endpoints.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Person))]
        public async Task<ActionResult<Person>> AddPerson([FromBody] Person person )
        {
            await personHandler.AddPersonAsync(person);

            return CreatedAtAction("GetPerson",
                new { id = person.Id },
                person);
        }

        [HttpPut]
        [Route("person", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdatePerson([FromBody] Person person)
        {
            await personHandler.UpdatePersonAsync(person);

            return NoContent();
        }

        [HttpDelete]
        [Route("person/{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> DeletePerson(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            await personHandler.DeletePersonAsync(id);

            return NoContent();
        }

        [HttpGet]
        [Route("person-addresses", Name = "GetPersonAddresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Address>>> GetPersonAddresses(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var addresses = await personHandler.GetPersonAddressesAsync(id);
            return Ok(addresses);
        }

        [HttpGet]
        [Route("addresses/{id}", Name = "GetAddresses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> GetAddress(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var addresses = await personHandler.GetAddressAsync(id);
            return Ok(addresses);
        }


        [HttpPost]
        [Route("person-address", Name = "AddAddress")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Address))]
        public async Task<ActionResult<Address>> AddAddress([FromBody] Address address)
        {
            await personHandler.AddAddressAsync(address);

            return CreatedAtAction("GetAddress",
                new { id = address.Id },
                address);
        }

        [HttpGet]
        [Route("person-contacts", Name = "GetPersonContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Address>>> GetPersonContacts(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var contacts = await personHandler.GetPersonContactsAsync(id);
            return Ok(contacts);
        }

        [HttpGet]
        [Route("contacts/{id}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contact>> GetContact(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest();
            }

            var contact = await personHandler.GetContactAsync(id);
            return Ok(contact);
        }


        [HttpPost]
        [Route("person-contact", Name = "AddContact")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Contact))]
        public async Task<ActionResult<Contact>> AddContact([FromBody] Contact contact)
        {
            await personHandler.AddContactAsync(contact);

            return CreatedAtAction("GetContact",
                new { id = contact.Id },
                contact);
        }
    }
}