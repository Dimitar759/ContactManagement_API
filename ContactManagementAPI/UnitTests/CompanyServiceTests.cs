using AutoMapper;
using DataAccess.Interface;
using Domain;
using DTO;
using Moq;
using Services.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class CompanyServiceTests
    {
        private readonly Mock<IRepository<Company>> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CompanyService _service;

        public CompanyServiceTests()
        {
            _mockRepo = new Mock<IRepository<Company>>();
            _mockMapper = new Mock<IMapper>();
            _service = new CompanyService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllCompanies_ReturnsCompanyList()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company { CompanyId = 1, CompanyName = "Dimsa" },
                new Company { CompanyId = 2, CompanyName = "Aktiv" }
            };

            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(companies);

            // Mock the mapping behavior
            var companyDtos = new List<CompanyDto>
            {
                new CompanyDto { CompanyId = 1, CompanyName = "Dimsa" },
                new CompanyDto { CompanyId = 2, CompanyName = "Aktiv" }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<CompanyDto>>(companies)).Returns(companyDtos);

            // Act
            var result = await _service.GetAllCompanies();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Dimsa", result[0].CompanyName);
        }
    }
}
