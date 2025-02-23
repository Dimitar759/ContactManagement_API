using AutoMapper;
using DataAccess.Interface;
using Domain;
using Moq;
using Services.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using DTO;

namespace UnitTests
{
    public class CountryServiceTests
    {
        private readonly Mock<IRepository<Country>> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CountryService _service;

        public CountryServiceTests()
        {
            _mockRepo = new Mock<IRepository<Country>>();
            _mockMapper = new Mock<IMapper>();
            _service = new CountryService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllCountries_ReturnsCountryList()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { CountryId = 1, CountryName = "USA" },
                new Country { CountryId = 2, CountryName = "Canada" }
            };

            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(countries);

            // Mock the mapping behavior
            var countryDtos = new List<CountryDto>
            {
                new CountryDto { CountryId = 1, CountryName = "USA" },
                new CountryDto { CountryId = 2, CountryName = "Canada" }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<CountryDto>>(countries)).Returns(countryDtos);

            // Act
            var result = await _service.GetAllCountries();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("USA", result[0].CountryName);
        }
    }
}
