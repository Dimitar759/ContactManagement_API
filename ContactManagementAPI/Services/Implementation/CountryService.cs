using AutoMapper;
using DataAccess.Implementation;
using DataAccess.Interface;
using Domain;
using DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task CreateCountry(CreateCountryRequestDto request)
        {
            var country = _mapper.Map<Country>(request);
            await _countryRepository.Add(country);
        }

        public async Task<List<CountryDto>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAll();
            return _mapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto?> GetCountryById(int id)
        {
            var country = await _countryRepository.GetById(id);
            return country == null ? null : _mapper.Map<CountryDto>(country);
        }

        public async Task UpdateCountry(UpdateCountryRequestDto request, int id)
        {
            var country = await _countryRepository.GetById(id);
            if (country != null)
            {
                _mapper.Map(request, country);
                await _countryRepository.Update(country);
            }
        }

        public async Task DeleteCountry(int id)
        {
            var country = await _countryRepository.GetById(id);
            if (country != null)
            {
                await _countryRepository.Delete(country);
            }
        }

    }
}
