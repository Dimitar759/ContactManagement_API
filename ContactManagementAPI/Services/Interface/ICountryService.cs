using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICountryService
    {
        Task CreateCountry(CreateCountryRequestDto request);
        Task<List<CountryDto>> GetAllCountries();
        Task<CountryDto?> GetCountryById(int id);
        Task UpdateCountry(UpdateCountryRequestDto request, int id);
        Task DeleteCountry(int id);

    }
}
