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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonHandler personHandler;

        public PersonController(ILogger<PersonController> logger, IPersonHandler personHandler)
        {
            _logger = logger;
            this.personHandler = personHandler ?? throw new ArgumentNullException(nameof(personHandler));
        }

        [HttpGet(Name = "GetList")]
        public IEnumerable<Person> Get()
        {
            //TODO: add decorations according to http standards
            return this.personHandler.GetList();
        }
    }
}