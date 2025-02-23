using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactRequestDto request)
        {
            try
            {
                await _contactService.CreateContact(request);
                return Ok(new { Message = "Contact created successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating contact");
                return Problem("An error occurred while creating the contact.", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> GetAllContacts()
        {
            try
            {
                var contacts = await _contactService.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving contacts");
                return Problem("An error occurred while fetching contacts.", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            try
            {
                var contact = await _contactService.GetContactById(id);
                if (contact == null)
                {
                    _logger.LogWarning($"Contact with ID {id} not found.");
                    return NotFound(new { Message = "Contact not found" });
                }
                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching contact with ID {id}");
                return Problem("An error occurred while fetching the contact.", statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactRequestDto request)
        {
            try
            {
                await _contactService.UpdateContact(request, id);
                return Ok(new { Message = "Contact updated successfully!" });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Contact with ID {id} not found for update.");
                return NotFound(new { Message = "Contact not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating contact with ID {id}");
                return Problem("An error occurred while updating the contact.", statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteContact(id);
                return Ok(new { Message = "Contact deleted successfully!" });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Contact with ID {id} not found for deletion.");
                return NotFound(new { Message = "Contact not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting contact with ID {id}");
                return Problem("An error occurred while deleting the contact.", statusCode: 500);
            }
        }

        [HttpGet("WithCompanyAndCountry")]
        public async Task<ActionResult<List<ContactDetailsDto>>> GetContactsWithCompanyAndCountry()
        {
            var contacts = await _contactService.GetContactsWithCompanyAndCountry();
            return Ok(contacts);
        }
    }
}
