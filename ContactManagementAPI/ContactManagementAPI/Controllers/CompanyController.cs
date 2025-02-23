using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequestDto request)
        {
            try
            {
                await _companyService.CreateCompany(request);
                return Ok(new { Message = "Company created successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating company");
                return Problem("An error occurred while creating the company.", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> GetAllCompanies()
        {
            try
            {
                var companies = await _companyService.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving companies");
                return Problem("An error occurred while fetching companies.", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyById(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyById(id);
                if (company == null)
                {
                    _logger.LogWarning($"Company with ID {id} not found.");
                    return NotFound(new { Message = "Company not found" });
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching company with ID {id}");
                return Problem("An error occurred while fetching the company.", statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyRequestDto request)
        {
            try
            {
                await _companyService.UpdateCompany(request, id);
                return Ok(new { Message = "Company updated successfully!" });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Company with ID {id} not found for update.");
                return NotFound(new { Message = "Company not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating company with ID {id}");
                return Problem("An error occurred while updating the company.", statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                await _companyService.DeleteCompany(id);
                return Ok(new { Message = "Company deleted successfully!" });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Company with ID {id} not found for deletion.");
                return NotFound(new { Message = "Company not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting company with ID {id}");
                return Problem("An error occurred while deleting the company.", statusCode: 500);
            }
        }
    }
}
