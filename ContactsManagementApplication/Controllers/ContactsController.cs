using ContactsManagementApplication.Dto;
using ContactsManagementApplication.Models;
using ContactsManagementApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllContacts")]

        public IActionResult GetAllContacts()
        {
            try
            {
                List<ContactDto> contacts = _repository.GetAllContacts().ToList();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet, Route("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                var contact = _repository.GetContactById(id);
                return contact == null ? NotFound(new { Message = "Contact not found." }) : Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact([FromBody] Contact contact)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _repository.AddContact(contact);
                    return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact([FromBody] Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _repository.UpdateContact(contact);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete, Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _repository.DeleteContact(id);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("Search")]
        public IActionResult SearchContacts([FromQuery] string query)
        {
            try
            {
                return Ok(_repository.SearchContacts(query));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet("Sort")]
        public IActionResult GetSortedContacts([FromQuery] string orderBy, [FromQuery] bool ascending)
        {
            try
            {
                return Ok(_repository.GetSortedContacts(orderBy, ascending));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet("Paginate")]
        public IActionResult GetPaginatedContacts([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var result = _repository.GetPaginatedContacts(page, pageSize);
                return Ok(new { data = result.data, hasNext = result.hasNext });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}

