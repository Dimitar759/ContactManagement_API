using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequestDto request)
        {
            try
            {
                await _countryService.CreateCountry(request);
                return StatusCode(StatusCodes.Status201Created, "Country created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> GetAllCountries()
        {
            try
            {
                var countries = await _countryService.GetAllCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountryById([FromRoute] int id)
        {
            try
            {
                var country = await _countryService.GetCountryById(id);
                if (country == null)
                {
                    return NotFound($"Country not found with ID {id}");
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry([FromRoute] int id, [FromBody] UpdateCountryRequestDto request)
        {
            try
            {
                await _countryService.UpdateCountry(request, id);
                return Ok("Country updated");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            try
            {
                await _countryService.DeleteCountry(id);
                return Ok("Country deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error: {ex.Message}");
            }
        }
    }
}
