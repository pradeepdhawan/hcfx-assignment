using Contact.Api.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contact.Api.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IDataRepository<Contact.Api.Models.Contact> _dataRepository;

        public ContactController(IDataRepository<Contact.Api.Models.Contact> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Contact
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Contact.Api.Models.Contact> contacts = _dataRepository.GetAll();
            return Ok(contacts);
        }

        // GET: api/Contact/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Contact.Api.Models.Contact contact = _dataRepository.Get(id);

            if (contact == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            return Ok(contact);
        }

        // POST: api/Contact
        [HttpPost]
        public IActionResult Post([FromBody] Contact.Api.Models.Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }
            try
            {
                _dataRepository.Add(contact);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return CreatedAtRoute(
                  "Get",
                  new { Id = contact.ContactId },
                  contact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Contact.Api.Models.Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }

            Contact.Api.Models.Contact contactToUpdate = _dataRepository.Get(id);
            if (contactToUpdate == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }
            try
            {
                _dataRepository.Update(contactToUpdate, contact);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return NoContent();
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Contact.Api.Models.Contact contact = _dataRepository.Get(id);
            if (contact == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            _dataRepository.Delete(contact);
            return NoContent();
        }
    }
}