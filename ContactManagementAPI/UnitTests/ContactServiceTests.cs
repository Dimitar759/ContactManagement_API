using AutoMapper;
using DataAccess.Implementation;
using DataAccess.Interface;
using Domain;
using Moq;
using Xunit;  
using DTO;
using Services.Implementation;

namespace UnitTests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly ContactService _service;
        private readonly IMapper _mapper;

        public ContactServiceTests()
        {
            _mockRepo = new Mock<IContactRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDetailsDto>()
                 .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company!.CompanyName))
                 .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country!.CountryName));

            });

            _mapper = config.CreateMapper();
            _service = new ContactService(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetContactsWithCompanyAndCountry_ReturnsMappedContacts()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact { ContactId = 1, ContactName = "Dimitar", Company = new Company { CompanyName = "Aktiv" }, Country = new Country { CountryName = "USA" } },
                new Contact { ContactId = 2, ContactName = "Nick", Company = new Company { CompanyName = "Aktiv" }, Country = new Country { CountryName = "Canada" } }
            };

            _mockRepo.Setup(repo => repo.GetContactsWithCompanyAndCountry()).ReturnsAsync(contacts);

            // Act
            var result = await _service.GetContactsWithCompanyAndCountry();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John Doe", result[0].ContactName);
            Assert.Equal("TechCorp", result[0].CompanyName);
            Assert.Equal("USA", result[0].CountryName);
        }
    }
}
