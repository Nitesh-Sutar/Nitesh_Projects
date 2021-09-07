using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAPI.Interfaces;
using ContactAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        #region Private fields
        private readonly ILogger<ContactController> _logger;
        private IContactRepository _contactRepository;
        #endregion
        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        #region API METHODS
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Contact>> GetAllContacts()
        {
            try
            {
                _logger.LogInformation("Fetching all the contacts from the Database");

                var contactList = await _contactRepository.GetAllContacts().ConfigureAwait(false);

                _logger.LogInformation($"Returning {contactList.Count} contacts.");

                if (contactList is null || !contactList.Any())
                {
                    return NotFound();
                }
                return Ok(contactList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion
    }
}
